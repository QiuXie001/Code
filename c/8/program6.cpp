//实验6任务：
//创建无向图的邻接矩阵并输出，从指定的顶点k进行DFS遍历。1、编写完成主函数。 
//增加内容：2、增加一条边，验证结果；3、删除一个顶点，验证结果 
#include<stdio.h>
#include<stdlib.h>
#define OK  1
#define ERROR  0
typedef  int Status;
//用两个数组分别存储顶点表和邻接矩阵                   
#define MVNum 100    
int visited[MVNum];                   
typedef char VerTexType;              	
typedef int ArcType;                	
typedef struct{ 
  VerTexType vexs[MVNum];            	
  ArcType arcs[MVNum][MVNum];      	
  int vexnum,arcnum;                		
}AMGraph; 
int LocateVex(AMGraph G,VerTexType u){
   int i;//存在则返回u在顶点表中的下标;否则返回-1
   for(i=0;i<G.vexnum;++i)
     if(u==G.vexs[i])
       return i;
   return -1;
}
Status CreateUDN(AMGraph &G){
	int i,j,k;
	char v1,v2;
	scanf("%d%d",&G.vexnum,&G.arcnum);
	getchar();//1
	for(i=0;i<G.vexnum;i++)
		G.vexs[i]=getchar();
	getchar();//2
	for(i=0;i<G.vexnum;i++)
		for(j=0;j<G.vexnum;j++)
			G.arcs[i][j]=0;//MaxInt
	for( k=0;k<G.arcnum;k++){
		scanf("%c%c",&v1,&v2); 	
		getchar();//3
		i=LocateVex(G,v1);if(i==-1) return ERROR;//modi 2
		j=LocateVex(G,v2);if(j==-1) return ERROR;
		G.arcs[i][j]=G.arcs[j][i]=1;
	}
	return OK;
}
void Prn(AMGraph G){
	int i,j;
	for(i=0;i<G.vexnum;i++)
		printf("%c\t",G.vexs[i]);//modi 1
	printf("\n");
	for(i=0;i<G.vexnum;i++){
		for(j=0;j<G.vexnum;j++)
			printf("%d\t",G.arcs[i][j]);
		printf("\n");
	}	
}
void DFS(AMGraph G, int v){  
  printf("%d\t",v);  visited[v] = 1;  
  for(int w = 0; w< G.vexnum; w++)   
        if((G.arcs[v][w]!=0)&& (!visited[w]))  
            DFS(G, w);  
}


Status InsertArc(AMGraph &G) {
	//插入1条边；
	printf("输入边\n");
	char v1,v2;
	scanf("%c%c",&v1,&v2);
	getchar();
	G.arcs[LocateVex(G, v1)][LocateVex(G, v2)] = G.arcs[LocateVex(G, v2)][LocateVex(G, v1)] = 1;
    printf("between vertices %c and %c.\n", v1, v2);
	G.arcnum++;
	return OK; 
}
Status DeleteVex(AMGraph &G){
	VerTexType v;
	int n=0;
	//删除1个顶点；
	printf("输入一个顶点\n");
	scanf("%c",&v);
	getchar();
	int k=LocateVex(G,v);
	for(int i=0;i<G.vexnum;i++)
	if(G.arcs[k][i])
	n++;
	
       // 前移
       for (int i = LocateVex(G,v)+1; i < G.vexnum; i++) 
	   {
		G.vexs[i-1]=G.vexs[i];
       }
	   for (int i = LocateVex(G,v)+1; i < G.vexnum; i++) 
	   	{
			for(int j=0;j<G.vexnum;j++)
			{
			G.arcs[i][j-1]=G.arcs[i][j];
		 	}
        }
	   for (int i = 0; i < G.vexnum; i++) 
	   	{
			for(int j=LocateVex(G,v)+1;j<G.vexnum;j++)
			{
			G.arcs[i-1][j]=G.arcs[i][j];
		 	}
        }
       // 更新顶点数
       G.vexnum--;
       G.arcnum -= n ;
       return OK;
}


int main(){
	AMGraph G;
	CreateUDN(G);
	Prn(G);
	InsertArc(G);
	Prn(G);
	DeleteVex(G);
	Prn(G);
	return 1;
}






 

