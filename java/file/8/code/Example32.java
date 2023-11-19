package com.itheima;

import java.text.SimpleDateFormat;
import java.util.Date;

public class Example32 {
    public static void main(String[] args) {
        // 创建一个SimpleDateFormat对象
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy年MM月dd日");
        // 按SimpleDateFormat对象的日期模板格式化Date对象
        System.out.println(sdf.format(new Date()));
    }
}
