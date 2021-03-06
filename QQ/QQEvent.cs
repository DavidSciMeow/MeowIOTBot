﻿ using Newtonsoft.Json.Linq;
using static MeowIOTBot.NetworkHelper.PostHelper;
using System;
using System.Threading.Tasks;

namespace MeowIOTBot.QQ.QQEvent
{
    /// <summary>
    /// 群通知大类
    /// </summary>
    public class ON_EVENT_GROUP_ADMINSYSNOTIFY
    {
        /// <summary>
        /// 
        /// </summary>
        public long Seq;
        /// <summary>
        /// 
        /// </summary>
        public long Type;
        /// <summary>
        /// 
        /// </summary>
        public string MsgTypeStr;
        /// <summary>
        /// 
        /// </summary>
        public long Who;
        /// <summary>
        /// 
        /// </summary>
        public string WhoName;
        /// <summary>
        /// 
        /// </summary>
        public string MsgStatusStr;
        /// <summary>
        /// 
        /// </summary>
        public string Content;
        /// <summary>
        /// 
        /// </summary>
        public string RefuseContent;
        /// <summary>
        /// 
        /// </summary>
        public long Flag_7;
        /// <summary>
        /// 
        /// </summary>
        public long Flag_8;
        /// <summary>
        /// 
        /// </summary>
        public long GroupId;
        /// <summary>
        /// 
        /// </summary>
        public string GroupName;
        /// <summary>
        /// 
        /// </summary>
        public long ActionUin;
        /// <summary>
        /// 
        /// </summary>
        public string ActionName;
        /// <summary>
        /// 
        /// </summary>
        public string ActionGroupCard;
        /// <summary>
        /// 
        /// </summary>
        public long Action;
    }
    /// <summary>
    /// 管理员变更事件
    /// </summary>
    public class ON_EVENT_GROUP_ADMIN
    {
        /// <summary>
        /// 标志,是否成为管理员
        /// </summary>
        public long Flag;
        /// <summary>
        /// 群号
        /// </summary>
        public long GroupID;
        /// <summary>
        /// 用户名
        /// </summary>
        public long UserID;
    }
    /// <summary>
    /// 群禁言事件
    /// </summary>
    public class ON_EVENT_GROUP_SHUT
    {
        /// <summary>
        /// 群名
        /// </summary>
        public long GroupID;
        /// <summary>
        /// 禁言时间(秒)
        /// </summary>
        public long ShutTime;
        /// <summary>
        /// 用户名
        /// </summary>
        public long UserID;
    }
    /// <summary>
    /// 群成员退出群聊事件
    /// </summary>
    public class ON_EVENT_GROUP_EXIT
    {
        /// <summary>
        /// 退出成员名
        /// </summary>
        public long UserID;
    }
    /// <summary>
    /// 主动退群成功事件
    /// </summary>
    public class ON_EVENT_GROUP_EXIT_SUCC
    {
        /// <summary>
        /// 退出的群
        /// </summary>
        public long GroupID;
    }
    /// <summary>
    /// 某人进群事件
    /// </summary>
    public class ON_EVENT_GROUP_JOIN
    {
        /// <summary>
        /// 被邀请人
        /// </summary>
        public long InviteUin;
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;
    }
    /// <summary>
    /// 邀请加群
    /// </summary>
    public class ON_EVENT_GROUP_ADMINSYSNOTIFY_INVITE_GROUP : ON_EVENT_GROUP_ADMINSYSNOTIFY
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="x"></param>
        public ON_EVENT_GROUP_ADMINSYSNOTIFY_INVITE_GROUP(ON_EVENT_GROUP_ADMINSYSNOTIFY x)
        {
            Seq = x.Seq;
            Type = x.Type;
            MsgTypeStr = x.MsgTypeStr;
            Who = x.Who;
            WhoName = x.WhoName;
            MsgStatusStr = x.MsgStatusStr;
            Content = x.Content;
            RefuseContent = x.RefuseContent;
            Flag_7 = x.Flag_7;
            Flag_8 = x.Flag_8;
            GroupId = x.GroupId;
            GroupName = x.GroupName;
            ActionUin = x.ActionUin;
            ActionName = x.ActionName;
            ActionGroupCard = x.ActionGroupCard;
            Action = x.Action;
        }
        /// <summary>
        /// 同意请求
        /// </summary>
        public async Task<string> RequestAccept()
        {
            var k = this;
            k.Action = 11;
            return await PASA(UrlType.AnswerInviteGroup, Newtonsoft.Json.JsonConvert.SerializeObject(k));
        }
        /// <summary>
        /// 拒绝请求
        /// </summary>
        public async Task<string> RequestDenied()
        {
            var k = this;
            k.Action = 21;
            return await PASA(UrlType.AnswerInviteGroup, Newtonsoft.Json.JsonConvert.SerializeObject(k));
        }
        /// <summary>
        /// 忽略请求
        /// </summary>
        public async Task<string> RequestDismiss()
        {
            var k = this;
            k.Action = 14;
            return await PASA(UrlType.AnswerInviteGroup, Newtonsoft.Json.JsonConvert.SerializeObject(k));
        }
    }
    /// <summary>
    /// 群成员撤回消息
    /// </summary>
    public class ON_EVENT_GROUP_REVOKE
    {
        /// <summary>
        /// 执行人
        /// </summary>
        public long AdminUserID;
        /// <summary>
        /// 执行群
        /// </summary>
        public long GroupID;
        /// <summary>
        /// 撤回消息的随机码
        /// </summary>
        public long MsgRandom;
        /// <summary>
        /// 撤回消息序号
        /// </summary>
        public long MsgSeq;
        /// <summary>
        /// 被执行人
        /// </summary>
        public long UserID;
    }
    /*------------------------------------------------------*/
    /// <summary>
    /// 加好友事件
    /// </summary>
    public class ON_EVENT_FRIEND_ADD
    {
        /// <summary>
        /// QQ号
        /// </summary>
        public long UserID;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNick;
        /// <summary>
        /// 来源类型
        /// </summary>
        public long FromType;
        /// <summary>
        /// 类型
        /// </summary>
        public long Type;
        /// <summary>
        /// 
        /// </summary>
        public string MsgTypeStr;
        /// <summary>
        /// 
        /// </summary>
        public long Field_3;
        /// <summary>
        /// 
        /// </summary>
        public long Field_8;
        /// <summary>
        /// 验证信息
        /// </summary>
        public string Content;
        /// <summary>
        /// 群信息
        /// </summary>
        public string FromContent;
        /// <summary>
        /// 来源群号
        /// </summary>
        public long FromGroupId;
        /// <summary>
        /// 来源群名
        /// </summary>
        public string FromGroupName;
        /// <summary>
        /// 
        /// </summary>
        public int Action;

        /// <summary>
        /// 同意请求
        /// </summary>
        public async Task<string> RequestAccept()
        {
            var k = this;
            k.Action = 2;
            return await PASA(UrlType.DealFriend, Newtonsoft.Json.JsonConvert.SerializeObject(k));
        }
        /// <summary>
        /// 拒绝请求
        /// </summary>
        public async Task<string> RequestDenied()
        {
            var k = this;
            k.Action = 3;
            return await PASA(UrlType.DealFriend, Newtonsoft.Json.JsonConvert.SerializeObject(k));
        }
        /// <summary>
        /// 忽略请求
        /// </summary>
        public async Task<string> RequestDismiss()
        {
            var k = this;
            k.Action = 1;
            return await PASA(UrlType.DealFriend, Newtonsoft.Json.JsonConvert.SerializeObject(k));
        }
    }
    /// <summary>
    /// 成为好友事件
    /// </summary>
    public class ON_EVENT_NOTIFY_PUSHADDFRD
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName;
        /// <summary>
        /// 用户
        /// </summary>
        public long UserID;
    }
    /// <summary>
    /// 好友状态信息事件(被同意添加好友/被拒绝添加好友)
    /// </summary>
    public class ON_EVENT_FRIEND_ADD_STATUS
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName;
        /// <summary>
        /// 类型
        /// </summary>
        public int Type;
        /// <summary>
        /// 类型状态
        /// </summary>
        public string TypeStatus;
        /// <summary>
        /// 用户QQ号
        /// </summary>
        public int UserID;
    }
    /// <summary>
    /// 删除好友事件
    /// </summary>
    public class ON_EVENT_FRIEND_DELETE
    {
        /// <summary>
        /// 用户QQ号
        /// </summary>
        public long UserID;
    }
    /// <summary>
    /// 事件类型枚举类
    /// <para>EventType EnumClass</para>
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 还没识别的事件类型
        /// </summary>
        ON_EVENT_NULL_REF,
        /*--------------------------*/
        /// <summary>
        /// 管理员设置事件
        /// </summary>
        ON_EVENT_GROUP_ADMINSYSNOTIFY,
        /// <summary>
        /// 管理员变更事件
        /// </summary>
        ON_EVENT_GROUP_ADMIN,
        /// <summary>
        /// 群禁言
        /// </summary>
        ON_EVENT_GROUP_SHUT,
        /// <summary>
        /// 群成员退出群聊事件
        /// </summary>
        ON_EVENT_GROUP_EXIT,
        /// <summary>
        /// 主动退群成功事件
        /// </summary>
        ON_EVENT_GROUP_EXIT_SUCC,
        /// <summary>
        /// 某人进群事件
        /// </summary>
        ON_EVENT_GROUP_JOIN,
        /// <summary>
        /// 某人邀你进群
        /// </summary>
        ON_EVENT_GROUP_ADMINSYSNOTIFY_INVITE_GROUP,
        /// <summary>
        /// 群成员撤回消息
        /// </summary>
        ON_EVENT_GROUP_REVOKE,
        /*-------------*/
        /// <summary>
        /// 某人加你好友
        /// </summary>
        ON_EVENT_FRIEND_ADD,
        /// <summary>
        /// 某人不再是你的好友
        /// </summary>
        ON_EVENT_FRIEND_DELETE
    }
    /// <summary>
    /// 事件的摘要
    /// <para>Event Hash</para>
    /// </summary>
    public class EventMsg
    {
        /// <summary>
        /// 构造用
        /// </summary>
        /// <param name="jo"></param>
        public EventMsg(JObject jo)
        {
            if (jo.TryGetValue("EventMsg", out var EventMsg))
            {
                var em = JObject.Parse(EventMsg.ToString());
                em.TryGetValue("FromUin", out var FromUin);
                this.FromUser = FromUin?.ToObject<long>() ?? 0;
                em.TryGetValue("ToUin", out var ToUin);
                this.ToUser = ToUin?.ToObject<long>() ?? 0;
                em.TryGetValue("MsgType", out var MsgType);
                this.MsgType = MsgType?.ToString();
                em.TryGetValue("MsgSeq", out var MsgSeq);
                this.MsgSeq = MsgSeq?.ToObject<long>() ?? 0;
                em.TryGetValue("Content", out var Content);
                this.Content = Content?.ToString();
            }
            else { throw new Exception(EC.E00); }
        }
        /// <summary>
        /// 其他数据(扩展类)
        /// <para>eXtensionClass - for InnerData</para>
        /// </summary>
        public object Data { get; } = null;
        /// <summary>
        /// 来源用户
        /// <para>For The Msg From</para>
        /// </summary>
        public long FromUser { get; }
        /// <summary>
        /// 接收用户
        /// <para>For The Msg To</para>
        /// </summary>
        public long ToUser { get; }
        /// <summary>
        /// 信息类型
        /// <para>MsginnerType</para>
        /// </summary>
        public string MsgType { get; }
        /// <summary>
        /// 消息序列号
        /// <para>Msg Sequence</para>
        /// </summary>
        public long MsgSeq { get; }
        /// <summary>
        /// 信息内容
        /// <para>Msg Innerexcption</para>
        /// </summary>
        public string Content { get; }
    }
    /// <summary>
    /// 继承用事件内部数据类
    /// <para>for inherit classes (which is EventData-Typed)</para>
    /// </summary>
    public class Event
    {
        /// <summary>
        /// 构造用
        /// </summary>
        /// <param name="jo"></param>
        public Event(JObject jo)
        {
            EMsg = new EventMsg(jo);
            if (jo.TryGetValue("EventName", out var EventName))
            {
                var en = EventName.ToString();
                this.EType = en switch
                {
                    "ON_EVENT_GROUP_ADMIN" => EventType.ON_EVENT_GROUP_ADMIN,
                    "ON_EVENT_GROUP_ADMINSYSNOTIFY" => EventType.ON_EVENT_GROUP_ADMINSYSNOTIFY,
                    "ON_EVENT_GROUP_SHUT" => EventType.ON_EVENT_GROUP_SHUT,
                    "ON_EVENT_GROUP_EXIT" => EventType.ON_EVENT_GROUP_EXIT,
                    "ON_EVENT_GROUP_EXIT_SUCC" => EventType.ON_EVENT_GROUP_EXIT_SUCC,
                    "ON_EVENT_GROUP_JOIN" => EventType.ON_EVENT_GROUP_JOIN,
                    "ON_EVENT_FRIEND_ADD" => EventType.ON_EVENT_FRIEND_ADD,
                    "ON_EVENT_GROUP_REVOKE" => EventType.ON_EVENT_GROUP_REVOKE,
                    _ => EventType.ON_EVENT_NULL_REF
                };
            }
            else { throw new Exception(EC.E01); }
            if (jo.TryGetValue("EventData", out var EventData))
            {
                JObject jed = JObject.Parse(EventData.ToString());
                this.Data = EventName.ToString() switch
                {
                    "ON_EVENT_GROUP_ADMIN" => jed.ToObject<ON_EVENT_GROUP_ADMIN>(),
                    "ON_EVENT_GROUP_ADMINSYSNOTIFY" => jed.ToObject<ON_EVENT_GROUP_ADMINSYSNOTIFY>(),
                    "ON_EVENT_GROUP_SHUT" => jed.ToObject<ON_EVENT_GROUP_SHUT>(),
                    "ON_EVENT_GROUP_EXIT" => jed.ToObject<ON_EVENT_GROUP_EXIT>(),
                    "ON_EVENT_GROUP_EXIT_SUCC" => jed.ToObject<ON_EVENT_GROUP_EXIT_SUCC>(),
                    "ON_EVENT_GROUP_JOIN" => jed.ToObject<ON_EVENT_GROUP_JOIN>(),
                    "ON_EVENT_FRIEND_ADD" => jed.ToObject<ON_EVENT_FRIEND_ADD>(),
                    "ON_EVENT_GROUP_REVOKE" => jed.ToObject<ON_EVENT_GROUP_REVOKE>(),
                    _ => null
                };
            }
            else { throw new Exception(EC.E02); }
        }
        /// <summary>
        /// 枚举类型(用于转换下面的InnerData)
        /// <para>inner Class For Cast InnerData</para>
        /// </summary>
        public EventType EType { get; } = EventType.ON_EVENT_NULL_REF;
        /// <summary>
        /// 事件的摘要信息
        /// <para>Event Hash</para>
        /// </summary>
        public EventMsg EMsg { get; } = null;
        /// <summary>
        /// 事件的内部转换信息
        /// <para>inner DataCast -> Object</para>
        /// </summary>
        public object Data { get; }
    }
}
