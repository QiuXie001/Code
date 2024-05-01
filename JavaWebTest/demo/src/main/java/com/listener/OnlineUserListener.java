package com.listener;


import javax.servlet.ServletContext;
import javax.servlet.annotation.WebListener;
import javax.servlet.http.HttpSession;
import javax.servlet.http.HttpSessionEvent;
import javax.servlet.http.HttpSessionListener;

@WebListener
public class OnlineUserListener implements HttpSessionListener {
    public static int onlineUserCount = 0;

    //当一个用户打开网站的时候开启创建session执行的方法
    public void sessionCreated(HttpSessionEvent httpSessionEvent) {
       System.out.println("=====有一位用户上线了=====");
       System.out.println("Id: "+httpSessionEvent.getSession().getId()+"=====");
       
       OnlineUserListener.onlineUserCount++;
       HttpSession session = httpSessionEvent.getSession();
       
       ServletContext application = session.getServletContext();
       application.setAttribute("onlineUserCount",onlineUserCount);
    }
   //关闭网站的时候销毁session执行的的方法
   public void sessionDestroyed(HttpSessionEvent httpSessionEvent) {
       System.out.println("=====用户下线了=====");
       System.out.println("Id: "+httpSessionEvent.getSession().getId()+"=====");
       
       
       OnlineUserListener.onlineUserCount--;
       
       HttpSession session = httpSessionEvent.getSession();
       ServletContext application = session.getServletContext();
       application.setAttribute("onlineUserCount",onlineUserCount);
    }
}
