﻿using MeowIOTBot.ObjectEvent;
using Newtonsoft.Json.Linq;
using System;

namespace MeowIOTBot.Basex
{
    /// <summary>
    /// 代理的类
    /// <para>DelegateLibrary</para>
    /// <code>
    /// <para>用法如下 (Usage)</para>
    /// <para>using var c = new MeowClient("url", "qq");</para>
    /// <para>c.Connect();</para>
    /// <para>c.OnServerAction += (s, e) =>{};</para>
    /// </code>
    /// </summary>
    public partial class MeowClient : IDisposable
    {
        /// <summary>
        /// 日志记录标志
        /// <para>decided if you want to Console.Write(log)</para>
        /// <para>this can be dynamically</para>
        /// </summary>
        public static LogType logFlag { get; set; }
        /// <summary>
        /// 后端的处理位置
        /// <para>Backends Url</para>
        /// </summary>
        public string url { get; }
        /// <summary>
        /// socket标
        /// <para>socket Client Variable</para>
        /// </summary>
        private SocketIOClient.SocketIO socket = null;
        /// <summary>
        /// 构造代理的类
        /// <para>DelegateLibrary</para>
        /// <code>
        /// <para>用法如下 (Usage)</para>
        /// <para>using var c = new MeowClient("url", "qq");</para>
        /// <para>c.Connect();</para>
        /// <para>c.OnServerAction += (s, e) =>{};</para>
        /// </code>
        /// </summary>
        /// <param name="logflag">
        /// 是否打印日志
        /// <para>if you want have an Log</para>
        /// </param>
        /// <param name="url">
        /// ws的连接Client位置 例如 ws://localhost:10000
        /// <para>Ws connection backend, like wise 'ws://localhost:10000'</para>
        /// </param>
        public MeowClient(string url, LogType logflag = LogType.None)
        {
            logFlag = logflag;
            this.url = url;
        }
        /// <summary>
        /// 连接并获取最原始的Client对象
        /// <para>Connect and get Object Client</para>
        /// </summary>
        public MeowClient Connect()
        {
            socket = new(url);
            socket.ConnectAsync();
            socket.OnConnected += (s, e) =>
            {
                ServerUtil.Log($"{socket.ServerUri} is connected",LogType.None);
            };
            socket.OnPing += async (s, e) =>
            {
                ServerUtil.Log($"server - ping", LogType.ServerMessage);
                await socket.EmitAsync("Ping", "heartbeat");
            };
            socket.OnPong += (s, e) =>
            {
                ServerUtil.Log($"client - pong check {e}", LogType.ServerMessage);
            };
            socket.OnDisconnected += (s, e) =>
            {
                ServerUtil.Log($"{socket.ServerUri} closed - retrying reconnect", LogType.ServerMessage);
            };
            socket.OnReconnecting += (s, e) =>
            {
                ServerUtil.Log($"{socket.ServerUri} reconnecting", LogType.ServerMessage);
            };

            socket.On("OnGroupMsgs", (fn) => {
                var x = new ObjectEventArgs(JObject.Parse(fn.GetValue(0).ToString()));
                OnServerAction.Invoke(new object(), x);
                OnGroupMsgs.Invoke(new object(), x);
            });
            socket.On("OnFriendMsgs", (fn) => {
                var x = new ObjectEventArgs(JObject.Parse(fn.GetValue(0).ToString()));
                OnServerAction.Invoke(new object(), x);
                OnFriendMsgs.Invoke(new object(), x);
            });
            socket.On("OnEvents", (fn) => {
                var x = new ObjectEventArgs(JObject.Parse(fn.GetValue(0).ToString()));
                OnServerAction.Invoke(new object(), x);
                OnEventMsgs.Invoke(new object(), x);
            });
            return this;
        }
        /// <summary>
        /// 强制关闭Socket连接
        /// <para>force close Socket</para>
        /// </summary>
        public void Close()
        {
            try
            {
                if (socket != null)
                {
                    socket = null; // close & dispose of socket client
                }
            }
            catch
            {
                socket = null;
                GC.Collect();
            }
        }
        /// <summary>
        /// 关闭连接
        /// <para>normally dispose</para>
        /// </summary>
        public void Dispose() => Close();
    }
    public partial class MeowClient : IDisposable
    {
        /// <summary>
        /// 服务器的总体事件集合委托
        /// <para>On Server Message delegate</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ObjectEventHandler(object sender, ObjectEventArgs e);
        /// <summary>
        /// 服务器的总体事件集合 (如果你重写这个事件,那么服务端的解析将可以由您自己决定)
        /// <para>On Server Message (if you rewrite the Build Core will fail)</para>
        /// </summary>
        public event ObjectEventHandler OnServerAction;
        /// <summary>
        /// 服务器群聊消息事件委托
        /// <para>Serveric [OnGroup] Message Delegate</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GroupMessageEventHandler(object sender, ObjectEventArgs e);
        /// <summary>
        /// 服务器群聊消息事件 (如果你重写这个事件,那么服务端的解析将可以由您自己决定)
        /// <para>Serveric [OnGroup] Message Event (if you rewrite the Build Core will fail)</para>
        /// </summary>
        public event GroupMessageEventHandler OnGroupMsgs;
        /// <summary>
        /// 服务器好友消息事件委托
        /// <para>Serveric [OnFriend] Message Delegate</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void FriendMessageEventHandler(object sender, ObjectEventArgs e);
        /// <summary>
        /// 服务器好友消息事件 (如果你重写这个事件,那么服务端的解析将可以由您自己决定)
        /// <para>Serveric [OnFriend] Message Event (if you rewrite the Build Core will fail)</para>
        /// </summary>
        public event FriendMessageEventHandler OnFriendMsgs;
        /// <summary>
        /// 服务器事件消息事件委托
        /// <para>Serveric [OnEvent] Message Delegate</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventMessageEventHandler(object sender, ObjectEventArgs e);
        /// <summary>
        /// 服务器事件消息事件 (如果你重写这个事件,那么服务端的解析将可以由您自己决定)
        /// <para>Serveric [OnEvent] Message Event (if you rewrite the Build Core will fail)</para>
        /// </summary>
        public event EventMessageEventHandler OnEventMsgs;
    }
}
