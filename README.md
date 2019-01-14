# MemorySessionProvider

自定义的ASP.NET Session 会话存储程序，在不影响性能的情况下（使用Memorycache存储会话信息），解决Session丢失的问题（在session超时之前就丢失）。

使用方法：

1. 添加程序集引用

2. 在web.config中做如下配置：
```xml
<system.web>
  <sessionState timeout="20" mode="Custom" customProvider="MemorySessionProvider">
    <providers>
      <add name="MemorySessionProvider" type="MemorySessionProvider.SessionProvider,MemorySessionProvider"/>
    </providers>
  </sessionState>
</system.web> 
```
=================================

Custom session store provider, that can solve the problem of lost Session frequently, but there is no performance impact.

Usage:

1. Add the assembly reference.

2. Add this configuration in web.config:
```xml
<system.web>
  <sessionState timeout="20" mode="Custom" customProvider="MemorySessionProvider">
    <providers>
      <add name="MemorySessionProvider" type="MemorySessionProvider.SessionProvider,MemorySessionProvider"/>
    </providers>
  </sessionState>
</system.web> 
```
