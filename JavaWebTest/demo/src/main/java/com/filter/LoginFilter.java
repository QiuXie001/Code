package com.filter;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import java.io.IOException;

@WebFilter("/*")
public class LoginFilter implements Filter {
    private String excludedPage;
    private String[] excludedPages;

    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        excludedPage = "/demo/LoginServlet,/demo/CheckServlet";// 此处的ignores就是在web.xml定义的名称一样。
        if (excludedPage != null && excludedPage != "") {
            excludedPages = excludedPage.split(",");
        }
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
        HttpServletRequest httpRequest = (HttpServletRequest) request;
        HttpServletResponse httpResponse = (HttpServletResponse) response;
        HttpSession session = httpRequest.getSession();
        boolean flag = false;
        if (httpRequest.getRequestURI().equals(excludedPages[0]) && session.getAttribute("LoginState") != null) {
            httpResponse.sendRedirect(httpRequest.getContextPath() + "/WorkManage/shows");
        } 
        else {
            for (String page : excludedPages) {
                if (httpRequest.getRequestURI().equals(page)) {
                    flag = true;
                }
            }
            if (flag) {
                chain.doFilter(request, response);
            } else {

                String username = (String) session.getAttribute("username");
                String LoginState = (String) session.getAttribute("LoginState");
                if (username == null || username == "" || LoginState == null) {
                    // 用户未登录，重定向到登录页面
                    httpResponse.sendRedirect(httpRequest.getContextPath() + "/LoginServlet");
                } else {
                    // 用户已登录，继续处理请求
                    chain.doFilter(request, response);
                }
            }
        }
    }

    @Override
    public void destroy() {

    }
}