package com.itheima;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Example37 {
    public static void main(String[] args) {
        Pattern p1 = Pattern.compile("a*b");        //根据参数指定的正则表达式创建模式
        Matcher m1 = p1.matcher("aaaaab");    //获取目标字符串的匹配器
        Matcher m2 = p1.matcher("aaabbb");    //获取目标字符串的匹配器
        System.out.println(m1.matches());           //执行匹配器
        System.out.println(m2.matches());           //执行匹配器
        Pattern p2 = Pattern.compile("[/]+");
        String[] str = p2.split("张三//李四/王五//赵六/钱七"); //按模式分割字符串
        for(String s : str){
            System.out.print(s+"\t");
        }
    }
}
