package com.itheima;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Example38 {
    public static void main(String[] args) {
        Pattern p=Pattern.compile("\\d+");
        Matcher m=p.matcher("22bb23");
        System.out.println("字符串是否匹配:"+ m.matches());
        Matcher m2=p.matcher("2223");
        System.out.println("字符串2223与模式p是否匹配:"+ m2.matches());
        System.out.println("字符串22bb23与模式p的匹配结果:"+ m.lookingAt());
        Matcher m3=p.matcher("aa2223");
        System.out.println("字符串aa2223与模式p的匹配结果:"+m3.lookingAt());
        System.out.println("字符串22bb23与模式p是否存在下一个匹配结果:"+
                m.find());
        m3.find();//返回true
        System.out.println("字符串aa2223与模式p是否存在在下一个匹配结果："+
                m3.find());
        Matcher m4=p.matcher("aabb");
        System.out.println("字符串aabb与模式p是否存在下一个匹配结果："+
                m4.find());
        Matcher m1=p.matcher("aaa2223bb");
        m1.find();//匹配2223
        System.out.println("模式p与字符串aaa2223bb的匹配的起始索引:"+
                m1.start());
        System.out.println("模式p与字符串aaa2223bb的最后一个字符匹配后的偏移量"+
                m1.end());
        System.out.println("模式p与字符串aaa2223bb的匹配到的子字符串:"+
                m1.group());
        Pattern p2 = Pattern.compile("[/]+");
        Matcher m5 = p2.matcher("张三/李四//王五///赵六");
        System.out.println("将字符串张三/李四//王五///赵六中的/全部替换为|:"+
                m5.replaceAll("|"));
        System.out.println("将字符串张三/李四//王五///赵六中的首个/替换为|:"+
                m5.replaceFirst("|"));
    }
}
