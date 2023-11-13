package com.itheima;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

public class Example25 {
    public static void main(String[] args) {
        //获取日期时分秒
        LocalDate now = LocalDate.now();
        LocalDate of = LocalDate.of(2015, 12, 12);
        System.out.println("1. LocalDate的获取及格式化的相关方法--------");
        System.out.println("从LocalDate实例获取当前的年份是："+now.getYear());
        System.out.println("从LocalDate实例获取当前的月份是："
                +now.getMonthValue());
        System.out.println("从LocalDate实例获取当天为本月的第几天："
                +now.getDayOfMonth());
        System.out.println("将获取到的Loacaldate实例格式化后是："
                +now.format(DateTimeFormatter.ofPattern("yyyy年MM月dd日")));
        System.out.println("2. LocalDate判断的相关方法----------------");
        System.out.println("判断日期of是否在now之前："+of.isBefore(now));
        System.out.println("判断日期of是否在now之后："+of.isAfter(now));
        System.out.println("判断日期of和now是否相等："+now.equals(of));
        System.out.println("判断日期of是否是闰年："+ of.isLeapYear());
        //给出一个符合默认格式要求的日期字符串
        System.out.println("3. LocalDate解析以及加减操作的相关方法---------");
        String dateStr="2020-02-01";
        System.out.println("把日期字符串解析成日期对象的结果是："
                +LocalDate.parse(dateStr));
        System.out.println("将LocalDate实例年份加1后的结果是："
                +now.plusYears(1));
        System.out.println("将LocalDate实例天数减10后的结果是："
                +now.minusDays(10));
        System.out.println("将LocalDate实例的年份设置为2014后的结果是："
                +now.withYear(2014));
    }
}
