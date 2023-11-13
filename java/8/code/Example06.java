package com.itheima;

public class Example06 {
    public static void main(String[] args) {
        String str = "石家庄-武汉-哈尔滨";
        // 下面是字符串截取操作
        System.out.println("从第5个字符截取到末尾的结果：" +
                str.substring(4));
        System.out.println("从第5个字符截取到第6个字符的结果：" +
                str.substring(4, 6));
        // 下面是字符串分割操作
        System.out.print("分割后的字符串数组中的元素依次为:");
        String[] strArray = str.split("-"); // 将字符串转换为字符串数组
        for (int i = 0; i < strArray.length; i++) {
            if (i != strArray.length - 1) {
                // 如果不是数组的最后一个元素,在元素后面加逗号
                System.out.print(strArray[i] + ",");
            } else {
                // 数组的最后一个元素后面不加逗号
                System.out.println(strArray[i]);
            }
        }
    }
}
