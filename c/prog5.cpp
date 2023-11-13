//开机，启动最后一个系统；
//实验五内容   字符串的应用
//1：内容已经完成了指定数据结构的赋值（串）、输出、经典模式匹配算法； 
//2：同学完成插入、比较、统计、连接等操作； 
//3：主函数结果要求；
//   （1）赋值2个串，"chinese","china",并输出检验正确性；
//    (2)比较上述两串大小；依据比较结果，将大的串，输出；
//    (3)将第2个串，插入到第1串的第5个位置前，并输出结果；
//    (4)将第2串连接到第1串的尾部，并输出结果；
//    (5)统计字串“is”在主串“this is fistiskis ok"中出现的次数；
 
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#define OK   1
#define ERROR  0
typedef  int  Status;
#define MAXLEN  255
typedef  struct{
    char  ch[MAXLEN+1];
    int length;
}SString;

int Index(SString S,SString T,int pos){//搜索字串
    int i=pos,j=1;
    while(i<=S.length&&j<=T.length){
        if(S.ch[i]==T.ch[j]){i++;j++;}
        else {i=i-j+2;  j=1;}
    }
    if(j>T.length) return i-T.length;
    else  return 0;
}

Status StrAssign(SString &T,char *ch){//串的赋值
    int i=0;
    while(ch[i]){ //while(ch[i]!='\0')
        T.ch[i+1]=ch[i]; i++;
    }
    T.length=i;
    return OK;
}

void Prn(SString S){
    for(int i=1;i<=S.length;i++)
        putchar(S.ch[i]);
    printf("\n");
}

int StrCompare(SString S,SString T){//比较字符串S和T的大小；对位比较大小，返回差值； 
    int len=S.length < T.length ? S.length : T.length;
    for(int i=1; i<=len; i++){
        if(S.ch[i] != T.ch[i]) return S.ch[i] - T.ch[i];
    }
    return S.length - T.length;
}

Status StrInsert(SString &S,SString T,int pos){//插入字符串，在串S的pos开始的位置上插入串T； 
    if(pos<1 || pos >S.length+1 || S.length+T.length>MAXLEN) return ERROR;
    for(int i=S.length; i>=pos; i--){
        S.ch[i+T.length] = S.ch[i];
    }
    for(int i=pos, j=1; j<=T.length; i++, j++){
        S.ch[i] = T.ch[j];
    }
    S.length += T.length;
    return OK;
}

Status StrCat(SString &S,SString T) {//将串T，连接到串S的尾部； 
    if(S.length + T.length > MAXLEN) return ERROR;
    for(int i=1, j=S.length+1; i<=T.length; i++, j++){
        S.ch[j] = T.ch[i];
    }
    S.length += T.length;
    return OK;
}

int Count(SString S,SString T,int pos){//统计字串T出现在串S中的次数； 
    int count=0;
    int i=pos;
    while(i<=S.length){
        int index = Index(S, T, i);
        if(index==0) break;
        count++;
        i=index+1;
    }
    return count;
}

int  main(){
    SString S, T;
    char ch[] = "chinese";
    char ch2[] = "china";
    StrAssign(S, ch);
    Prn(S);
    StrAssign(T, ch2);
    Prn(T);
    int result = StrCompare(S, T);
    if(result > 0){
        Prn(S);
    }else if(result < 0){
        Prn(T);
    }else{
        printf("Equal!\n");
    }
    StrInsert(S, T, 5);
    Prn(S);
	StrAssign(S, ch);
	StrAssign(T, ch2);
    StrCat(S, T);
    Prn(S);
    char ch3[] = "this is fistiskis ok";
    SString S1, T1;
    StrAssign(S1, ch3);
    char ch4[] = "is";
    StrAssign(T1, ch4);
    int count = Count(S1, T1, 1);
    printf("count=%d\n", count);
    return 0;
}