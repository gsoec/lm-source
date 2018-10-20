.class public Lcom/igg/iggsdkbusiness/GCMBroadcastReceiver;
.super Lcom/igg/sdk/push/IGGGcmBroadcastReceiver;
.source "GCMBroadcastReceiver.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 22
    invoke-direct {p0}, Lcom/igg/sdk/push/IGGGcmBroadcastReceiver;-><init>()V

    return-void
.end method


# virtual methods
.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 3
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 26
    const-string v1, "GcmBroadcastReceiver"

    const-string v2, "--------onReceive------"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 27
    const-string v1, "Receiver service:"

    const-class v2, Lcom/igg/iggsdkbusiness/GCMIntentService;

    invoke-virtual {v2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 29
    new-instance v0, Landroid/content/ComponentName;

    invoke-virtual {p1}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    const-class v2, Lcom/igg/iggsdkbusiness/GCMIntentService;

    .line 30
    invoke-virtual {v2}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v0, v1, v2}, Landroid/content/ComponentName;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 32
    .local v0, "comp":Landroid/content/ComponentName;
    invoke-virtual {p2, v0}, Landroid/content/Intent;->setComponent(Landroid/content/ComponentName;)Landroid/content/Intent;

    move-result-object v1

    invoke-static {p1, v1}, Lcom/igg/iggsdkbusiness/GCMBroadcastReceiver;->startWakefulService(Landroid/content/Context;Landroid/content/Intent;)Landroid/content/ComponentName;

    .line 33
    const/4 v1, -0x1

    invoke-virtual {p0, v1}, Lcom/igg/iggsdkbusiness/GCMBroadcastReceiver;->setResultCode(I)V

    .line 34
    return-void
.end method
