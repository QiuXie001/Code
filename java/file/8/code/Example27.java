package com.itheima;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class Example27 {
    public static void main(String[] args) {
        //获取系统当前年月日时分秒
        LocalDateTime now = LocalDateTime.now();
        System.out.println("获取的当前日期时间为:"+now);
        System.out.println("将目标LocalDateTime转换为相应的LocalDate实例:"+
                now.toLocalDate());
        System.out.println("将目标LocalDateTime转换为相应的LocalTime实例:"+
                now.toLocalTime());
        //指定格式
        DateTimeFormatter ofPattern = DateTimeFormatter.ofPattern
                ("yyyy年MM月dd日 HH时mm分ss秒");
        System.out.println("格式化后的日期时间为:"+now.format(ofPattern));
    }
}
