package com.itheima;

public class Example39 {
    public static void main(String[] args) {
        String str = "A1B22DDS34DSJ9D".replaceAll("\\d+","_");
        System.out.println("字符串替换后为："+str);
        boolean te = "321123as1".matches("\\d+");
        System.out.println("字符串是否匹配："+te);
        String[] s="SDS45d4DD4dDS88D".split("\\d+");
        System.out.print("字符串拆分后为：");
        for(int i=0;i<s.length;i++){
            System.out.print(s[i]+"  ");
        }
    }
}
