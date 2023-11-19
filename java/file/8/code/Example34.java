package com.itheima;

import java.text.NumberFormat;
import java.util.Locale;

public class Example34 {
    public static void main(String[] args) {
        double price = 18.01;   //定义货币
        int number = 1000010000;//定义数字
        //按照当前默认语言环境的货币格式显示
        NumberFormat nf = NumberFormat.getCurrencyInstance();
        System.out.println("按照当前默认语言环境的货币格式显示："
                + nf.format(price));
        //按照指定的语言环境的货币格式显示
        nf = NumberFormat.getCurrencyInstance(Locale.US);
        System.out.println("按照指定的语言环境的货币格式显示："
                + nf.format(price));
        //按照当前默认语言环境的数字格式显示
        NumberFormat nf2 = NumberFormat.getInstance();
        System.out.println("按照当前默认语言环境的数字格式显示："
                + nf2.format(number));
        //按照指定的语言环境的数字格式显示
        nf2 = NumberFormat.getInstance(Locale.US);
        System.out.println("按照指定的语言环境的数字格式显示："
                + nf.format(number));
    }
}
