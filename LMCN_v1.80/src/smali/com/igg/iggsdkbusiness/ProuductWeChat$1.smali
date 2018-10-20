.class Lcom/igg/iggsdkbusiness/ProuductWeChat$1;
.super Ljava/lang/Object;
.source "ProuductWeChat.java"

# interfaces
.implements Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$IGGPaymentCardsLoadedListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/ProuductWeChat;->getProduct()V
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
    .line 128
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentCardsLoaded(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;)V
    .locals 5
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "result"    # Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;

    .prologue
    .line 131
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v1

    if-eqz v1, :cond_0

    .line 133
    const-string v1, "WeChatPay"

    const-string v2, "onPaymentItemsLoadFinished"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 135
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-virtual {p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getIGGGameItems()Ljava/util/ArrayList;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->access$000(Lcom/igg/iggsdkbusiness/ProuductWeChat;Ljava/util/List;)Ljava/lang/String;

    move-result-object v0

    .line 136
    .local v0, "itemStr":Ljava/lang/String;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    new-instance v2, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-virtual {v3}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->getActivity()Landroid/app/Activity;

    move-result-object v3

    iget-object v4, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v4, v4, Lcom/igg/iggsdkbusiness/ProuductWeChat;->IGGID:Ljava/lang/String;

    invoke-direct {v2, v3, v4}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;-><init>(Landroid/app/Activity;Ljava/lang/String;)V

    iput-object v2, v1, Lcom/igg/iggsdkbusiness/ProuductWeChat;->alipayHelp:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    .line 137
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    const/4 v2, 0x1

    invoke-static {v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->access$102(Lcom/igg/iggsdkbusiness/ProuductWeChat;Z)Z

    .line 138
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    invoke-virtual {p2}, Lcom/igg/sdk/payment/google/composing/IGGPaymentCardsLoader$Result;->getPurchaseLimit()I

    move-result v2

    invoke-static {v1, v2}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->access$202(Lcom/igg/iggsdkbusiness/ProuductWeChat;I)I

    .line 140
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/ProuductWeChat$1;->this$0:Lcom/igg/iggsdkbusiness/ProuductWeChat;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/ProuductWeChat;->getProductCallBack:Ljava/lang/String;

    invoke-virtual {v1, v2, v0}, Lcom/igg/iggsdkbusiness/ProuductWeChat;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 141
    const-string v1, "WeChatPay"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "itemStr  = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 145
    .end local v0    # "itemStr":Ljava/lang/String;
    :goto_0
    return-void

    .line 143
    :cond_0
    const-string v1, "WeChatPay"

    const-string v2, "onPaymentItemsLoadFinished error"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
