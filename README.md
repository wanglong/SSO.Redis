# SSO.Redis
.NET基于Redis缓存实现单点登录SSO的解决方案
单点登录（Single Sign On），简称为 SSO，是目前比较流行的企业业务整合的解决方案之一。SSO的定义是在多个应用系统中，用户只需要登录一次就可以访问所有相互信任的应用系统。

普通的登录是写入session，每次获取session看看是否有登录就可记录用户的登录状态。

同理多个站点用一个凭证，可以用分布式session，我们可以用redis实现分布式session，来实现一个简单的统一登录demo
