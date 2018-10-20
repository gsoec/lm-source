.class Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;
.super Ljava/lang/Object;
.source "IGGAliPay.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

.field final synthetic val$body:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

.field final synthetic val$price:Ljava/lang/String;

.field final synthetic val$subject:Ljava/lang/String;

.field final synthetic val$timestamp:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    .prologue
    .line 59
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$subject:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$body:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$price:Ljava/lang/String;

    iput-object p6, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$timestamp:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onPaymentOrdersNoLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 9
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "orderNo"    # Ljava/lang/String;
    .param p3, "sign"    # Ljava/lang/String;
    .param p4, "notifyUrl"    # Ljava/lang/String;

    .prologue
    .line 64
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_2

    .line 65
    if-eqz p2, :cond_0

    const-string v0, ""

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 66
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;->onError()V

    .line 79
    :goto_0
    return-void

    .line 70
    :cond_1
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$subject:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$body:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$price:Ljava/lang/String;

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$timestamp:Ljava/lang/String;

    move-object v4, p2

    move-object v5, p4

    invoke-static/range {v0 .. v6}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->access$000(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    .line 72
    .local v8, "tempOrderInfo":Ljava/lang/String;
    move-object v7, v8

    .line 73
    .local v7, "payInfo":Ljava/lang/String;
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "&sign="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 74
    const-string v0, "IGGAliPay"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "payInfo:"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 75
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    invoke-static {v1}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->access$100(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;)Landroid/app/Activity;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-static {v0, v1, v7, v2}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->access$200(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    goto :goto_0

    .line 77
    .end local v7    # "payInfo":Ljava/lang/String;
    .end local v8    # "tempOrderInfo":Ljava/lang/String;
    :cond_2
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-interface {v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;->onError()V

    goto :goto_0
.end method
