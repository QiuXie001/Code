package com.itheima;

import java.time.LocalDate;
import java.time.Period;

public class Example29 {
    public static void main(String[] args) {
        LocalDate birthday = LocalDate.of(2018, 12, 12);
        LocalDate now = LocalDate.now();
        //计算两个日期的间隔
        Period between = Period.between(birthday, now);
        System.out.println("时间间隔为"+between.getYears()+"年");
        System.out.println("时间间隔为"+between.getMonths()+"月");
        System.out.println("时间间隔为"+between.getDays()+"天");
    }
}
