#include <stdio.h>
#include <stdlib.h>

// 定义索引表
typedef struct {
    int max;
    int pos;
} index; 
index b[3];

// 函数声明
void insertIndex(int a[], index* b, int blockSize);
int binarySearch(index b[],int key, int left, int right);
int linearSearch(int* array, int len, int key);

int main() {
    printf("开始测试\n");
    // 数据安排
    int a[] = {22,23,24,8,9,10,33,34,35,36,37,48,49,58,59,60,86,87};
    int len = sizeof(a) / sizeof(a[0]); 
    int blockSize = len / 3; 
    // 创建索引表
    index b[3];
    // 插入索引
    insertIndex(a, b, blockSize);
    
    printf("索引表初始化成功\n");
    // 查找数据
    int dataToFind[] = {22, 33, 86, 8, 48, 58, 100};
    for (int i = 0; i < sizeof(dataToFind) / sizeof(dataToFind[0]); i++) {
        int result = binarySearch(b, dataToFind[i], 0, 2);
        if (result == -1) {  
        printf("%d 没有对应的数据块\n", dataToFind[i]);  
        break; 
        } 
        for (int j = b[result].pos; j < b[result].pos + blockSize; j++)
        {
        if (a[j] == dataToFind[i]) {
            printf("%d   数据块%d 中的第%d个数据\n", dataToFind[i], result + 1, j-b[result].pos+1);
            break;
        } 
        if(j == b[result].pos + blockSize - 1){
            printf("%d 在数据块%d 中没有找到\n", dataToFind[i], result + 1); 
            break;
        }
        }
        
    }  
    return 0;
}


// 创建索引
void insertIndex(int a[], index* b, int blockSize) {
    for (int i = 0; i < 3; i++) {  
        b[i].max = a[i * blockSize];
        b[i].pos = i * blockSize;
        printf("b[%d].pos为%d\n",i,b[i].pos); 
        for (int j = 0; j < blockSize; j++) {  
            if (a[i * blockSize + j] > b[i].max) {
                printf("b[%d].max由%d变为",i,b[i].max);  
                b[i].max = a[i * blockSize + j];  
                printf("%d\n",b[i].max);
            }  
        }  
    }  
}

// 折半查找
int binarySearch(index b[],int key, int left, int right) {
    int mid;  
    while (left <= right) {  
        
		mid = (left + right) / 2; 
		 
        if (b[mid].max == key) {  
            return mid;  
        } else if (b[mid].max > key&&b[mid-1].max < key){
        	return mid;
		} else if (b[mid-1].max > key){
        	return mid-1;
		} else if (b[mid].max < key){  
            left = mid + 1;
        } else{  
            right = mid - 1;
        }  
    }  
    return -1;
}

// 顺序查找
int linearSearch(int* array, int len, int key) {
   for (int i = 0; i < len; i++) {
       if (array[i] == key) {
           return array[i];
       }
   }
   return NULL;
}