.class Lcom/igg/iggsdkbusiness/GCMRegister$1;
.super Landroid/content/BroadcastReceiver;
.source "GCMRegister.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/GCMRegister;->init()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/GCMRegister;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/GCMRegister;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/GCMRegister;

    .prologue
    .line 79
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/GCMRegister$1;->this$0:Lcom/igg/iggsdkbusiness/GCMRegister;

    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    return-void
.end method


# virtual methods
.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 4
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 85
    :try_start_0
    const-string v2, "GCM"

    const-string v3, " notification.registerReceiver - onReceive"

    invoke-static {v2, v3}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    invoke-virtual {p2}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v2

    const-string v3, "com.igg.sdk.push.NOTIFICATION_ACTION"

    invoke-virtual {v2, v3}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 89
    .local v1, "newMessage":Ljava/lang/String;
    const-string v2, "GCM"

    invoke-static {v2, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 94
    .end local v1    # "newMessage":Ljava/lang/String;
    :goto_0
    return-void

    .line 90
    :catch_0
    move-exception v0

    .line 92
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method
