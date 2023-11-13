package com.v1;


public class Example03_7 {
    static {
        System.out.println("静态代码块");
    }
    
    {
        System.out.println("构造代码块");
    }
    
    public Example03_7() {
        System.out.println("构造方法");
    }
    
    public void localBlock() {
        {
            System.out.println("局部代码块");
        }
    }
    
    public static void main(String[] args) {
        Example03_7 e1 = new Example03_7();
        Example03_7 e2 = new Example03_7();
        
        e1.localBlock(); 
        e2.localBlock(); 
    }
}

