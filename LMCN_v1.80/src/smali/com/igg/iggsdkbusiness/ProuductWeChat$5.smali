.class Lcom/igg/iggsdkbusiness/ProuductWeChat$5;
.super Ljava/lang/Object;
.source "ProuductWeChat.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/ProuductWeChat;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/ProuductWeChat;

    .prologue
    .line 458
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onError()V
    .locals 3

    .prologue
    .line 476
    const-string v0, "Alipay"

    const-string v1, "onError"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 477
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 479
    return-void
.end method

.method public onSuccess(Lcom/igg/iggsdkbusiness/Alipay/PayResult;)V
    .locals 3
    .param p1, "payResult"    # Lcom/igg/iggsdkbusiness/Alipay/PayResult;

    .prologue
    .line 469
    const-string v0, "Alipay"

    const-string v1, "onSuccess"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 470
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayCallBackSuccessful:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 472
    return-void
.end method

.method public onWaitResult()V
    .locals 3

    .prologue
    .line 462
    const-string v0, "Alipay"

    const-string v1, "onWaitResult"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 463
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$5;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPayConfirming:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 465
    return-void
.end method
