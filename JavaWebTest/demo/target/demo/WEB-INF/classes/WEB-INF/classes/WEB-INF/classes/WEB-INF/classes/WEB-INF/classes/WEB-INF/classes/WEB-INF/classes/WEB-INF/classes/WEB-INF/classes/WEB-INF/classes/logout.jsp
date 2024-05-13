<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>退出登录</title>
</head>
<body>
    <h1>退出登录成功！</h1>
    <a href="#" onclick="delayedRedirect(); return false;">返回登录页面</a>
</body>
</html>
<script>
function delayedRedirect() {
    // 延时3000毫秒（3秒）后跳转到指定的URL
    setTimeout(function() {
        window.location.href = '../demo/LoginServlet';
    }, 0);
}
</script>
