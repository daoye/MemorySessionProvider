# MemorySessionProvider

自定义ASP.NET Session 会话存储程序，可以解决Session频繁丢失的问题，而又没有性能影响。

使用方法：

1. 添加程序集引用

2. 在web.config中做如下配置：
    <system.web>
      <sessionState timeout="20" mode="Custom" customProvider="MemorySessionProvider">
        <providers>
          <add name="MemorySessionProvider" type="MemorySessionProvider.SessionProvider,MemorySessionProvider"/>
        </providers>
      </sessionState>
    </system.web> 

=================================

Custom session store provider, that can solve the problem of lost Session frequently, but there is no performance impact.

Usage:

1. Add the assembly reference.

2. Add this configuration in web.config:
    <system.web>
      <sessionState timeout="20" mode="Custom" customProvider="MemorySessionProvider">
        <providers>
          <add name="MemorySessionProvider" type="MemorySessionProvider.SessionProvider,MemorySessionProvider"/>
        </providers>
      </sessionState>
    </system.web> 
