#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

typedef struct
{
	char nickname[20];
	int socket;
}Usuario;				//Estructura Usuario

typedef struct
{
		Usuario Usuarios[10];
		int num;
}ListaConectados;		//Estructura lista de conectados

MYSQL *conn;
ListaConectados ListaConect;							//Definimos las variables globales (Lista de conectados y la conexion SQL)
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;		// Estructura para la exclusion mutua

void InicializarLista( ListaConectados *lista)			//Funcion para borrar la lista
{
	lista->num = 0;					
}

int AddUsuario( ListaConectados *lista, char nick[20], int socket)	//Funcion para añadir un usuario a la lista
{
	if (lista->num == 10)
	{
		return 1;
	}
	else 
	{
		strcpy(lista->Usuarios[lista->num].nickname,nick);
		lista->Usuarios[lista->num].socket = socket;
		lista->num = lista ->num + 1;
		return 0;
	}
}

int EliminarUsuario(ListaConectados *lista, char nick[20])			//Funcion para eliminar un usuario de la lista
{
	int encontrado = 0;
	int i = 0;
	while ((!encontrado) & (i < lista->num))
	{
		if (strcmp(lista->Usuarios[i].nickname,nick) == 0)
		{
			encontrado = 1;
		}
		else
			i = i + 1;
	}
	if (encontrado == 1)
	{
		int j = i+1;
		while (j < lista->num)
		{
			strcpy(lista->Usuarios[i].nickname,lista->Usuarios[j].nickname);
			lista->Usuarios[i].socket = lista->Usuarios[j].socket;
			i = i + 1;
			j = j + 1;
		}
		lista->num = lista->num - 1;
		return 0;
	}
	else
		return 1;
}

int SocketJugador(ListaConectados *lista, char nick[20])		//Funcion que devuelve el socket del usuario que le das
{
	int encontrado = 0;
	int i = 0;
	while ((!encontrado) & (i < lista->num))
	{
		if (strcmp(lista->Usuarios[i].nickname,nick) == 0)
		{
			encontrado = 1;
			return lista->Usuarios[i].socket;
		}
		else
			i = i + 1;
	}
	return -1;
}

	
int DarListaConectados(ListaConectados *lista, char respuesta[200])	//Escribe la lista de conectados en la respuestas
{
	char buffer[200];
	sprintf(buffer,"%s",lista->Usuarios[0].nickname);
	int i = 1;
	{
		while (i < lista->num)
		{
			sprintf(buffer,"%s,%s",buffer,lista->Usuarios[i].nickname);
			i = i + 1;
		}
		char buffer2[200];
		sprintf(buffer2,"%d/%s",i,buffer);
		strcpy(respuesta,buffer2);
	}
	return 0;
}


MYSQL *ConexionBaseDatos() 			//Funcion para abrir la conexion de la base de datos
{
	//Conexion con la base de datos
	MYSQL *conn;
	// Estructura especial para almacenar resultados de consultas 
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BaseDatos",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	return conn;
}

int ConexionSocket(int puerto)		//Funcion para abrir el socket
{
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	//INICIALIZACION
	
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error al crear Socket");
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	
	serv_adr.sin_family = AF_INET;
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); //ASIGNAMOS IP AL SOCKET
	
	serv_adr.sin_port = htons(puerto); //PUERTO DE ESCUCHA
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
	{
		printf ("Error al bind\n");
		
	}
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error al escuchar");
	
	return sock_listen;
};
int Registro(char mensaje[120],char nickname[20])		//Funcion para registrar un usuario en la base de datos
{
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nick[20]; 
	char password [25]; 
	char *p = strtok(mensaje, ",");
	strcpy(nick,p);
	strcpy(nickname,nick);
	p = strtok(NULL,",");	
	strcpy(password,p);
	char  consulta[128];
	err=mysql_query (conn,"SELECT MAX(Players.id) FROM Players");
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	int newid = atoi(row[0])+1;
	sprintf(consulta, "INSERT INTO Players VALUES ('%s','%s',%d,1,0)",nick,password,newid);
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	else
		printf("Registro completo\n");
		return 0;
}

int Acceso(char mensaje[120],char nickname[20])			//Funcion para iniciar sesion
{
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char nick[20]; 
	char password [25]; 
	char *p = strtok(mensaje, ",");
	strcpy(nick,p);
	strcpy(nickname,nick);
	p = strtok(NULL,",");	
	strcpy(password,p);
	char consulta[128];
	sprintf(consulta, "SELECT Players.passwo FROM Players WHERE Players.nombre = '%s'",nick);
	err=mysql_query (conn,consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
	{
		int login;
		char copia[25];
		strcpy(copia,row[0]);
		login = strcmp(password,copia);
		if (login == 0)
		{
			printf("Usuario conectado: %s\n",nick);
			return 0;
		}
		else
			return 1;
	}
}


int Consulta1(char mensaje[120], char respuesta[12])	//Consulta de partida mas larga de un jugador
{
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[200];
	sprintf(consulta,"SELECT MAX(Partidas.Turnos) FROM Players,Partidas,Relacion WHERE Players.id = Relacion.idJugador AND Relacion.idPartida = Partidas.id AND Players.nombre = '%s'",mensaje);
	err=mysql_query (conn,consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row[0] == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return 1;
	}
	else
	{
		strcpy(respuesta,row[0]);
		return 0;
	}
}



int Consulta2(char mensaje[120], char respuesta[64])	//Usuarios que han jugado una partida
{
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[200];
	sprintf(consulta,"SELECT nombre FROM Players WHERE id IN (select idJugador from Relacion WHERE idPartida=%s)",mensaje);
	err=mysql_query (conn,consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	resultado = mysql_store_result (conn);
	char buffer[64];
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return 1;
	}
	else
	{
		sprintf(buffer,"%s",row[0]);
		row = mysql_fetch_row (resultado);
		while (row !=NULL) 
		{
			sprintf(buffer,"%s,%s",buffer,row[0]);
			row = mysql_fetch_row (resultado);
		}
		strcpy(respuesta,buffer);
		return 0;
	}
}
int Consulta3(char mensaje[120], char numeropartidas[64])	//Partidas que tuviste tres pokemons
{
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[216];
	sprintf(consulta,"SELECT COUNT((Relacion.idPartida)) FROM Players,Partidas,Relacion WHERE Players.id = Relacion.idJugador AND Relacion.PokemonsRestantes = 3 AND Relacion.idPartida = Partidas.id AND Players.nombre ='%s'",mensaje);
	err=mysql_query (conn,consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row[0] == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		return 1;
	}
	else
	{
		strcpy(numeropartidas,row[0]);
		return 0;
	}
}



void *AtenderCliente( void *socket)			//Funcion que tiene que hacer el thread (codigo principal)
{
	int sock_conn = * (int *) socket;
	int ret;
	char entrada[512];
	char salida[512];
	int conectado = 1;
	while (conectado ==1)
	{
		ret=read(sock_conn,entrada, sizeof(entrada));
		printf ("Peticion Recibida\n");
		
		entrada[ret]='\0';
		salida[ret]='\0';
		
		char *p = strtok( entrada, "/");
		int codigo =  atoi (p);
		p = strtok( NULL, "/");
		char mensaje[200];
		strcpy (mensaje, p);
		printf ("Codigo: %d, Variables: %s\n", codigo, mensaje);
		char nick[20];

		if (codigo == 0)
		{
			conectado = 0;
			int error = EliminarUsuario(&ListaConect,mensaje);
			printf("Un usuario se ha desconectado\n");
		}
		
		if (codigo ==1) //Piden Registro
		{
			pthread_mutex_lock(&mutex);
			int respuesta = Registro(mensaje,nick);
			int add = AddUsuario(&ListaConect,mensaje,sock_conn);
			sprintf(salida,"%d",respuesta);
			pthread_mutex_unlock(&mutex);
			
		}
		if (codigo ==2) //Piden Acceso
		{
			pthread_mutex_lock(&mutex);
			int respuesta = Acceso(mensaje,nick);
			int add = AddUsuario(&ListaConect,mensaje,sock_conn);
			sprintf(salida,"%d",respuesta);
			pthread_mutex_unlock(&mutex);
		}
		if (codigo ==3) //Consulta 1
		{
			
			char maxturnos[12];
			int salidafuncion = Consulta1(mensaje,maxturnos);
			if (salidafuncion == 1)
			{
				strcpy(salida,"NoEncontrado");
			}
			if (salidafuncion == 0)
			{
				strcpy(salida,maxturnos);
			}
		}
		if (codigo == 4)
		{
			char listapartida[64];
			int salidafuncion = Consulta2(mensaje,listapartida);
			if (salidafuncion == 1)
			{
				strcpy(salida,"NoEncontrado");
			}
			if (salidafuncion == 0)
			{
				strcpy(salida,listapartida);
			}
		}
		
		if (codigo == 5)
		{
			char numeropartidas[12];
			int salidafuncion = Consulta3(mensaje,numeropartidas);
			if (salidafuncion == 1)
			{
				strcpy(salida,"NoEncontrado");
			}
			if (salidafuncion == 0)
			{
				strcpy(salida,numeropartidas);
			}
		}
		if (codigo == 6)
		{
			char listaconexiones[200];
			int respuesta = DarListaConectados(&ListaConect,listaconexiones);
			strcpy(salida,listaconexiones);
		}
		if (codigo != 0)
		{
			write (sock_conn,salida, strlen(salida));
		}
	}
	close(sock_conn);
}
int main(int argc, char *argv[])
{
	InicializarLista(&ListaConect);
	conn = ConexionBaseDatos();
	int sock_listen = ConexionSocket(9094);
	int sock_conn, ret, i;
	char entrada[512];
	char salida[512];
	pthread_t thread[10];
	int sockets[10];
	
	for(i = 0;;i++){
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		sockets[i] = sock_conn;
		printf ("Conexion establecida\n");
		pthread_create(&thread[i], NULL, AtenderCliente, &sockets[i]);
		}
}
	
