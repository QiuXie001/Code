#include <stdio.h>  
#include <stdlib.h>  
   
typedef struct {  
    int max;  
    int pos;  
} index;  
  
int search(index b[], int key, int left, int right) {  
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
  
void buildIndex(int a[], index b[], int blockSize) {  
    for (int i = 0; i < 3; i++) {  
        b[i].max = a[i * blockSize];
        b[i].pos = i * blockSize;
        for (int j = 1; j < blockSize; j++) {  
            if (a[i * blockSize + j] > b[i].max) {  
                b[i].max = a[i * blockSize + j];  
            }  
        }  
    }  
}  
  
void findData(int a[], index b[], int blockSize, int key) {  
    int block, index;  
    block = search(b, key, 0, 2);
    if (block == -1) {  
        printf("%d 没有对应的数据块\n", key);  
        return;  
    }  
    for (int i = b[block].pos; i < b[block].pos + blockSize; i++) { 
        if (a[i] == key) {  
            printf("%d 数据块%d 中的第%d个数据\n", key, block + 1, i - b[block].pos + 1);  
            return;  
        }  
    }  
    printf("%d 在数据块%d 中没有找到\n", key, block + 1);  
}  

int main() {  
    int a[] = {22, 12, 13, 8, 9, 20, 33, 42, 44, 38, 24, 48, 60, 58, 74, 49, 86, 53};  
    //22, 12, 13, 8, 9, 20 [0-5]22    33, 42, 44, 38, 24, 48 [6-11]    60, 58, 74, 49, 86, 53 [12-17]
    int blockSize = sizeof(a) / sizeof(int) / 3; 
    index b[3];  
    buildIndex(a, b, blockSize);
    findData(a, b, blockSize, 22);  
    findData(a, b, blockSize, 33);  
    findData(a, b, blockSize, 86);  
    findData(a, b, blockSize, 8);  
    findData(a, b, blockSize, 48);  
    findData(a, b, blockSize, 58);  
    findData(a, b, blockSize, 100);  
    return 0;  
}