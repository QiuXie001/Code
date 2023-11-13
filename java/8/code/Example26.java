package com.itheima;

import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class Example26 {
    public static void main(String[] args) {
        // 获取当前时间，包含毫秒数
        LocalTime time = LocalTime.now();
        LocalTime of = LocalTime.of(9,23,23);
        System.out.println("从LocalTime获取的小时为："+time.getHour());
        System.out.println("将获取到的LoacalTime实例格式化为："+
                time.format(DateTimeFormatter.ofPattern("HH:mm:ss")));
        System.out.println("判断时间of是否在now之前："+of.isBefore(time));
        System.out.println("将时间字符串解析为时间对象后为："+
                LocalTime.parse("12:15:30"));
        System.out.println("从LocalTime获取当前时间，不包含毫秒数："+
                time.withNano(0));
    }
}
