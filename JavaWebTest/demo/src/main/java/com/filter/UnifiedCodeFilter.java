package com.filter;
import javax.servlet.*;
import javax.servlet.annotation.WebFilter;

import java.io.IOException;


@WebFilter("/*")
public class UnifiedCodeFilter implements Filter{
    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException {
        servletRequest.setCharacterEncoding("UTF-8");
        servletResponse.setCharacterEncoding("UTF-8");
        servletResponse.setContentType("text/html;charset=UTF-8");
        filterChain.doFilter(servletRequest, servletResponse);
    }
    @Override
    public void destroy() {
        // 销毁过滤器时执行的操作，通常为空
    }
}
