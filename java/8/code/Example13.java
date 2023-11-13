package com.itheima;

public class Example13 {
    public static void main(String[] args) {
        Runtime rt = Runtime.getRuntime(); // 创建Runtime对象
        System.out.println("处理器的个数: " + rt.availableProcessors()+"个");
        System.out.println("空闲内存数量: " + rt.freeMemory() / 1024 / 1024
                + "MB");
        System.out.println("最大可用内存数量: " + rt.maxMemory() / 1024 /
                1024 + "MB");
        System.out.println("内存总容量: " + rt.totalMemory() / 1024 /
                1024 + "MB");
    }
}
