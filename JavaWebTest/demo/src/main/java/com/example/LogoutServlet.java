package com.example;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet("/LogoutServlet")
public class LogoutServlet extends HttpServlet{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

                HttpSession session = request.getSession();
                session.setAttribute("username","");
                session.setAttribute("password","");
                session.setAttribute("LoginState",null);
                session.invalidate();
                request.getRequestDispatcher("/WEB-INF/logout.jsp").forward(request, response);
		
    }
}
