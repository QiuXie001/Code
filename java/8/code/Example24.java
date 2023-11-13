package com.itheima;
import java.time.Instant;

public class Example24 {
    public static void main(String[] args) {
        //  Instant 类的时间戳类从1970-01-01 00:00:00 截止到当前时间的毫秒值
        Instant now = Instant.now();
        System.out.println("从系统获取的当前时刻为："+now);
        Instant instant = Instant.ofEpochMilli(1000 * 60 * 60 * 24);
        System.out.println("计算机元年增加1000 * 60 * 60 * 24毫秒数后为："
                +instant);
        Instant instant1 = Instant.ofEpochSecond(60 * 60 * 24);
        System.out.println("计算机元年增加60 * 60 * 24秒数后为："
                +instant1);
        System.out.println("获取的秒值为："
                +Instant.parse("2007-12-03T10:15:30.44Z").getEpochSecond());
        System.out.println("获取的纳秒值为："
                +Instant.parse("2007-12-03T10:15:30.44Z").getNano());
        System.out.println("从时间对象获取的Instant实例为："+
                Instant.from(now));
    }
}