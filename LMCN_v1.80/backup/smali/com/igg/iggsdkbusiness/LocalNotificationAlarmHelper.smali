.class public Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;
.super Ljava/lang/Object;
.source "LocalNotificationAlarmHelper.java"


# static fields
.field private static instance:Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private getActivity()Landroid/app/Activity;
    .locals 1

    .prologue
    .line 55
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->getActivity()Landroid/app/Activity;

    move-result-object v0

    return-object v0
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;
    .locals 1

    .prologue
    .line 48
    sget-object v0, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->instance:Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;

    if-nez v0, :cond_0

    .line 49
    new-instance v0, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->instance:Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;

    .line 51
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->instance:Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;

    return-object v0
.end method


# virtual methods
.method public Cancel(I)V
    .locals 6
    .param p1, "nid"    # I

    .prologue
    .line 38
    const-string v3, "Alarm"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "Cancel ID ="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 39
    new-instance v1, Landroid/content/Intent;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    const-class v4, Lcom/igg/iggsdkbusiness/LocalNotificationReceiver;

    invoke-direct {v1, v3, v4}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    .line 40
    .local v1, "intent":Landroid/content/Intent;
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    const/high16 v4, 0x10000000

    invoke-static {v3, p1, v1, v4}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v2

    .line 41
    .local v2, "pi":Landroid/app/PendingIntent;
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->getActivity()Landroid/app/Activity;

    move-result-object v3

    invoke-virtual {v3}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v3

    const-string v4, "alarm"

    invoke-virtual {v3, v4}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/app/AlarmManager;

    .line 42
    .local v0, "am":Landroid/app/AlarmManager;
    invoke-virtual {v0, v2}, Landroid/app/AlarmManager;->cancel(Landroid/app/PendingIntent;)V

    .line 43
    return-void
.end method

.method public SetAlarm(ILjava/lang/String;I)V
    .locals 8
    .param p1, "nid"    # I
    .param p2, "msg"    # Ljava/lang/String;
    .param p3, "sec"    # I

    .prologue
    .line 17
    const-string v5, "Alarm"

    const-string v6, "SetAlarm - Start"

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 18
    const-string v5, "Alarm"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "nid = "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 19
    const-string v5, "Alarm"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "msg = "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 20
    const-string v5, "Alarm"

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "sec"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 21
    invoke-static {}, Ljava/util/Calendar;->getInstance()Ljava/util/Calendar;

    move-result-object v2

    .line 22
    .local v2, "cal":Ljava/util/Calendar;
    const/16 v5, 0xd

    invoke-virtual {v2, v5, p3}, Ljava/util/Calendar;->add(II)V

    .line 24
    new-instance v3, Landroid/content/Intent;

    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v5

    const-class v6, Lcom/igg/iggsdkbusiness/LocalNotificationReceiver;

    invoke-direct {v3, v5, v6}, Landroid/content/Intent;-><init>(Landroid/content/Context;Ljava/lang/Class;)V

    .line 25
    .local v3, "intent":Landroid/content/Intent;
    new-instance v1, Landroid/os/Bundle;

    invoke-direct {v1}, Landroid/os/Bundle;-><init>()V

    .line 26
    .local v1, "bundle":Landroid/os/Bundle;
    const-string v5, "nid"

    invoke-virtual {v1, v5, p1}, Landroid/os/Bundle;->putInt(Ljava/lang/String;I)V

    .line 27
    const-string v5, "msg"

    invoke-virtual {v1, v5, p2}, Landroid/os/Bundle;->putString(Ljava/lang/String;Ljava/lang/String;)V

    .line 28
    invoke-virtual {v3, v1}, Landroid/content/Intent;->putExtras(Landroid/os/Bundle;)Landroid/content/Intent;

    .line 30
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v5

    const/high16 v6, 0x10000000

    invoke-static {v5, p1, v3, v6}, Landroid/app/PendingIntent;->getBroadcast(Landroid/content/Context;ILandroid/content/Intent;I)Landroid/app/PendingIntent;

    move-result-object v4

    .line 32
    .local v4, "pi":Landroid/app/PendingIntent;
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/LocalNotificationAlarmHelper;->getActivity()Landroid/app/Activity;

    move-result-object v5

    invoke-virtual {v5}, Landroid/app/Activity;->getApplicationContext()Landroid/content/Context;

    move-result-object v5

    const-string v6, "alarm"

    invoke-virtual {v5, v6}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/app/AlarmManager;

    .line 33
    .local v0, "am":Landroid/app/AlarmManager;
    const/4 v5, 0x0

    invoke-virtual {v2}, Ljava/util/Calendar;->getTimeInMillis()J

    move-result-wide v6

    invoke-virtual {v0, v5, v6, v7, v4}, Landroid/app/AlarmManager;->set(IJLandroid/app/PendingIntent;)V

    .line 34
    const-string v5, "Alarm"

    const-string v6, "SetAlarm - End"

    invoke-static {v5, v6}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 35
    return-void
.end method
