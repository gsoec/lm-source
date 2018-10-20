.class Lcom/igg/iggsdkbusiness/WeChatHelper$2;
.super Ljava/lang/Object;
.source "WeChatHelper.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/WeChatHelper;->LoginWeChat()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field email:Ljava/lang/String;

.field final synthetic this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/WeChatHelper;)V
    .locals 1
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/WeChatHelper;

    .prologue
    .line 217
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 218
    const-string v0, ""

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->email:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public onError()V
    .locals 3

    .prologue
    .line 276
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/WeChatHelper;->WeChatLoginCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 277
    const-string v0, "WeChat"

    const-string v1, "RegisterWeChat onError"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 278
    return-void
.end method

.method public onSuccess(Ljava/lang/String;)V
    .locals 3
    .param p1, "result"    # Ljava/lang/String;

    .prologue
    .line 220
    const-string v0, "WeiXinLogin"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "weAuthCode: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 222
    new-instance v0, Lcom/igg/sdk/account/IGGAccountLogin;

    invoke-direct {v0}, Lcom/igg/sdk/account/IGGAccountLogin;-><init>()V

    new-instance v1, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/WeChatHelper$2$1;-><init>(Lcom/igg/iggsdkbusiness/WeChatHelper$2;)V

    invoke-virtual {v0, p1, v1}, Lcom/igg/sdk/account/IGGAccountLogin;->loginWithWeChat(Ljava/lang/String;Lcom/igg/sdk/account/LoginListener;)V

    .line 272
    return-void
.end method

.method public onUninstall()V
    .locals 3

    .prologue
    .line 283
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$2;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/WeChatHelper;->WeChatLoginCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 284
    const-string v0, "WeChat"

    const-string v1, "RegisterWeChat onUninstall"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 285
    return-void
.end method
