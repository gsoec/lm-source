.class Lcom/igg/iggsdkbusiness/ProuductWeChat$7;
.super Ljava/lang/Object;
.source "ProuductWeChat.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/ProuductWeChat;->AliPay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZF)V
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
    .line 538
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLimint()V
    .locals 3

    .prologue
    .line 541
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AmoutOfLimitCallBack:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 542
    return-void
.end method

.method public onRequestError()V
    .locals 3

    .prologue
    .line 545
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$7;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/ProuductWeChat;->AmoutOfLimitErrorCallBack:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 546
    return-void
.end method
