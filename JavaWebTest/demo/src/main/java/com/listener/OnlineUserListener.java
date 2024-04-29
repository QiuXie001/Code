package com.listener;

import javax.servlet.annotation.WebListener;
import javax.servlet.http.HttpSessionEvent;
import javax.servlet.http.HttpSessionListener;

@WebListener("/WorkManage/*")
public class OnlineUserListener implements HttpSessionListener{
    private static int onlineUserCount = 0;

    @Override
    public void sessionCreated(HttpSessionEvent event) {
        // 当有用户登录时，增加在线人数
        onlineUserCount++;
        event.getSession().getServletContext().setAttribute("onlineUserCount", onlineUserCount);
    }

    @Override
    public void sessionDestroyed(HttpSessionEvent event) {
        // 当有用户退出登录时，减少在线人数
        onlineUserCount--;
        event.getSession().getServletContext().setAttribute("onlineUserCount", onlineUserCount);
    }
}
