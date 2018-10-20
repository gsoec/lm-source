.class Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;
.super Ljava/lang/Object;
.source "AlipayHelper.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

.field final synthetic val$orderInfo:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    .prologue
    .line 62
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->val$orderInfo:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentOrdersNoLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 7
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "orderNo"    # Ljava/lang/String;
    .param p3, "extraData"    # Ljava/lang/String;
    .param p4, "extraData1"    # Ljava/lang/String;

    .prologue
    const/4 v5, 0x0

    .line 68
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v4

    if-eqz v4, :cond_2

    .line 69
    if-eqz p2, :cond_0

    const-string v4, ""

    invoke-virtual {p2, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 70
    :cond_0
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v4, v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$002(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Z)Z

    .line 71
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-interface {v4}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;->onError()V

    .line 87
    :goto_0
    return-void

    .line 75
    :cond_1
    move-object v0, p4

    .line 76
    .local v0, "notifyUrl":Ljava/lang/String;
    move-object v2, p3

    .line 77
    .local v2, "sign":Ljava/lang/String;
    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->val$orderInfo:Ljava/lang/String;

    .line 78
    .local v3, "tempOrderInfo":Ljava/lang/String;
    const-string v4, "[ORDERNO]"

    invoke-virtual {v3, v4, p2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v3

    .line 79
    const-string v4, "[NOTIFYURL]"

    invoke-virtual {v3, v4, v0}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v3

    .line 80
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "&sign=\""

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "\"&"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$100(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    .line 81
    .local v1, "payInfo":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$200(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;)Landroid/app/Activity;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-static {v4, v5, v1, v6}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$300(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V

    goto :goto_0

    .line 83
    .end local v0    # "notifyUrl":Ljava/lang/String;
    .end local v1    # "payInfo":Ljava/lang/String;
    .end local v2    # "sign":Ljava/lang/String;
    .end local v3    # "tempOrderInfo":Ljava/lang/String;
    :cond_2
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    invoke-static {v4, v5}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->access$002(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Z)Z

    .line 84
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    invoke-interface {v4}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;->onError()V

    goto :goto_0
.end method
