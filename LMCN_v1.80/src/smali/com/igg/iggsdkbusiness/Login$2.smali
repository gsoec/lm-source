.class Lcom/igg/iggsdkbusiness/Login$2;
.super Ljava/lang/Object;
.source "Login.java"

# interfaces
.implements Lcom/igg/sdk/account/LoginListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Login;->GuestLogin()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Login;

.field final synthetic val$guest:Lcom/igg/sdk/account/IGGDeviceGuest;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Login;Lcom/igg/sdk/account/IGGDeviceGuest;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Login;

    .prologue
    .line 216
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Login$2;->val$guest:Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLocalSessionExpired(ZLcom/igg/sdk/account/IGGAccountSession;)V
    .locals 2
    .param p1, "isExpired"    # Z
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 220
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    const-string v1, "onLocalSessionExpired... .."

    invoke-virtual {v0, v1}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 221
    return-void
.end method

.method public onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V
    .locals 8
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "session"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 225
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v3

    if-eqz v3, :cond_0

    .line 234
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/Login;->GuestLoginFailedCallBack:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v5

    invoke-static {v5}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 272
    :goto_0
    return-void

    .line 238
    :cond_0
    if-nez p2, :cond_1

    .line 240
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    const-string v4, "LoginFailedCallBack...session == null .."

    invoke-virtual {v3, v4}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 241
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/Login;->GuestLoginFailedCallBack:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/Login;->StringGuestLoginNull:Ljava/lang/String;

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 246
    :cond_1
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isValid()Z

    move-result v3

    if-eqz v3, :cond_3

    .line 248
    :try_start_0
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    const-string v4, "deviceGuest %s login successfully"

    const/4 v5, 0x1

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v6, 0x0

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/Login$2;->val$guest:Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-virtual {v7}, Lcom/igg/sdk/account/IGGDeviceGuest;->getReadableIdentifier()Ljava/lang/String;

    move-result-object v7

    aput-object v7, v5, v6

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 249
    const-string v3, "LoginDemo"

    const-string v4, "deviceGuest %s login successfully"

    const/4 v5, 0x1

    new-array v5, v5, [Ljava/lang/Object;

    const/4 v6, 0x0

    iget-object v7, p0, Lcom/igg/iggsdkbusiness/Login$2;->val$guest:Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-virtual {v7}, Lcom/igg/sdk/account/IGGDeviceGuest;->getReadableIdentifier()Ljava/lang/String;

    move-result-object v7

    aput-object v7, v5, v6

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 254
    :goto_1
    const-string v1, "0"

    .line 255
    .local v1, "pBind":Ljava/lang/String;
    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->isHasBind()Z

    move-result v3

    if-eqz v3, :cond_2

    .line 256
    const-string v1, "1"

    .line 258
    :cond_2
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ";"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ";"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Login$2;->val$guest:Lcom/igg/sdk/account/IGGDeviceGuest;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGDeviceGuest;->getReadableIdentifier()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ";"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 259
    .local v2, "result":Ljava/lang/String;
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    invoke-virtual {v3, v2}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 260
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v3, v3, Lcom/igg/iggsdkbusiness/Login;->GuestLoginSuccessfulCallBack:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "session.getIGGId() ="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "session.getAccesskey() ="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {p2}, Lcom/igg/sdk/account/IGGAccountSession;->getAccesskey()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "pBind ="

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 262
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/Login;->GuestLoginSuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v3, v4, v2}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0

    .line 250
    .end local v1    # "pBind":Ljava/lang/String;
    .end local v2    # "result":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 251
    .local v0, "e":Ljava/lang/Exception;
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 252
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_1

    .line 266
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_3
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    const-string v4, "LoginFailedCallBack error"

    invoke-virtual {v3, v4}, Lcom/igg/iggsdkbusiness/Login;->DebugLog(Ljava/lang/String;)V

    .line 267
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/Login;->GuestLoginFailedCallBack:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Login$2;->this$0:Lcom/igg/iggsdkbusiness/Login;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/Login;->StringGuestLoginFailed:Ljava/lang/String;

    invoke-virtual {v3, v4, v5}, Lcom/igg/iggsdkbusiness/Login;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto/16 :goto_0
.end method
