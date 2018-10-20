.class Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;
.super Ljava/lang/Object;
.source "AuthRequestReceiver.java"

# interfaces
.implements Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/AuthRequestReceiver;->onReceive(Landroid/content/Context;Landroid/content/Intent;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/AuthRequestReceiver;

.field final synthetic val$IGGId:Ljava/lang/String;

.field final synthetic val$gameId:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/AuthRequestReceiver;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/AuthRequestReceiver;

    .prologue
    .line 45
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;->this$0:Lcom/igg/iggsdkbusiness/AuthRequestReceiver;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;->val$gameId:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;->val$IGGId:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGetAuthCodeFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;)V
    .locals 4
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "authCode"    # Ljava/lang/String;
    .param p3, "description"    # Ljava/lang/String;

    .prologue
    .line 49
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 50
    const-string v1, "AuthRequestReceiver"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "getIMAuthCode:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 51
    new-instance v0, Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-direct {v0}, Lcom/igg/android/wegamers/auth/AuthInfo;-><init>()V

    .line 52
    .local v0, "authInfo":Lcom/igg/android/wegamers/auth/AuthInfo;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;->val$gameId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igg/android/wegamers/auth/AuthInfo;->setGameId(Ljava/lang/String;)V

    .line 53
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;->val$IGGId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igg/android/wegamers/auth/AuthInfo;->setGameUserId(Ljava/lang/String;)V

    .line 54
    invoke-virtual {v0, p2}, Lcom/igg/android/wegamers/auth/AuthInfo;->setToken(Ljava/lang/String;)V

    .line 55
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/AuthRequestReceiver$1;->val$IGGId:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igg/android/wegamers/auth/AuthInfo;->setUserIggId(Ljava/lang/String;)V

    .line 56
    const/4 v1, 0x0

    invoke-static {v1, v0}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->responseAuthResult(ILcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 61
    .end local v0    # "authInfo":Lcom/igg/android/wegamers/auth/AuthInfo;
    :goto_0
    return-void

    .line 58
    :cond_0
    const-string v1, "AuthRequestReceiver"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "description:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 59
    const/4 v1, 0x2

    const/4 v2, 0x0

    invoke-static {v1, v2}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->responseAuthResult(ILcom/igg/android/wegamers/auth/AuthInfo;)V

    goto :goto_0
.end method
