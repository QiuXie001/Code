package cn.demo.domain;

public class Student {
    private int sid;
    private String name;
    private double score;
    
    public Student(int sid, String name, double score) {
        this.sid = sid;
        this.name = name;
        this.score = score;
    }
    
    public void evaluation() {
        if (score > 90) {
            System.out.println(name + "是三好学生");
        } else {
            System.out.println(name + "是普通学生");
        }
    }
   
}