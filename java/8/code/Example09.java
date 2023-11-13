package com.itheima;

public class Example09 {
    public static void main(String[] args) {
        int[] fromArray = { 10, 11, 12, 13, 14, 15 };    // 源数组
        int[] toArray = { 20, 21, 22, 23, 24, 25, 26 }; // 目标数组
        System.arraycopy(fromArray, 2, toArray, 3, 4);  // 复制数组元素
        // 打印复制后数组的元素
        System.out.println("复制后的数组元素为：");
        for (int i = 0; i < toArray.length; i++) {
            System.out.print(toArray[i]+" ");
        }
    }
}
