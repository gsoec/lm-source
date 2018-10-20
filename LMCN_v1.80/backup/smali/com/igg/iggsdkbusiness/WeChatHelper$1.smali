.class Lcom/igg/iggsdkbusiness/WeChatHelper$1;
.super Ljava/lang/Object;
.source "WeChatHelper.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/WeChatHelper$WeChatLoginListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/WeChatHelper;->BindToWeChat()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/WeChatHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/WeChatHelper;

    .prologue
    .line 156
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onError()V
    .locals 3

    .prologue
    .line 201
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 202
    const-string v0, "WeChat"

    const-string v1, "RegisterWeChat onError"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 203
    return-void
.end method

.method public onSuccess(Ljava/lang/String;)V
    .locals 3
    .param p1, "result"    # Ljava/lang/String;

    .prologue
    .line 162
    move-object v0, p1

    .line 163
    .local v0, "weAuthCode":Ljava/lang/String;
    new-instance v1, Lcom/igg/sdk/account/IGGAccountBind;

    invoke-direct {v1}, Lcom/igg/sdk/account/IGGAccountBind;-><init>()V

    new-instance v2, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;

    invoke-direct {v2, p0}, Lcom/igg/iggsdkbusiness/WeChatHelper$1$1;-><init>(Lcom/igg/iggsdkbusiness/WeChatHelper$1;)V

    invoke-virtual {v1, v0, v2}, Lcom/igg/sdk/account/IGGAccountBind;->bindToWeChat(Ljava/lang/String;Lcom/igg/sdk/account/IGGAccountBind$BindWeChatListener;)V

    .line 196
    const-string v1, "WeChat"

    const-string v2, "RegisterWeChat onSuccess"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 197
    return-void
.end method

.method public onUninstall()V
    .locals 3

    .prologue
    .line 208
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/WeChatHelper$1;->this$0:Lcom/igg/iggsdkbusiness/WeChatHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/WeChatHelper;->BindWeChatCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/WeChatHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 209
    const-string v0, "WeChat"

    const-string v1, "RegisterWeChat onUninstall"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 210
    return-void
.end method
