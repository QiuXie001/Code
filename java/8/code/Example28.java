package com.itheima;

import java.time.Duration;
import java.time.LocalTime;

public class Example28 {
    public static void main(String[] args) {
        LocalTime start = LocalTime.now();
        LocalTime end = LocalTime.of(20,13,23);
        Duration duration = Duration.between(start, end);
        //间隔的时间
        System.out.println("时间间隔为："+duration.toNanos()+"纳秒");
        System.out.println("时间间隔为："+duration.toMillis()+"毫秒");
        System.out.println("时间间隔为："+duration.toHours()+"小时");
    }
}
