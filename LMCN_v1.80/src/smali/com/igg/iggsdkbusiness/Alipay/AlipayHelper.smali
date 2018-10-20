.class public Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;
.super Ljava/lang/Object;
.source "AlipayHelper.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;
    }
.end annotation


# static fields
.field private static final PARTNER:Ljava/lang/String; = "2088101137231227"

.field private static final SELLER:Ljava/lang/String; = "2088101137231227"


# instance fields
.field private activity:Landroid/app/Activity;

.field private iggId:Ljava/lang/String;

.field private isLocked:Z


# direct methods
.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;)V
    .locals 1
    .param p1, "activity"    # Landroid/app/Activity;
    .param p2, "iggId"    # Ljava/lang/String;

    .prologue
    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 21
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->isLocked:Z

    .line 38
    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->iggId:Ljava/lang/String;

    .line 39
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->activity:Landroid/app/Activity;

    .line 40
    return-void
.end method

.method static synthetic access$002(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Z)Z
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;
    .param p1, "x1"    # Z

    .prologue
    .line 15
    iput-boolean p1, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->isLocked:Z

    return p1
.end method

.method static synthetic access$100(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    .prologue
    .line 15
    invoke-direct {p0}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->getSignType()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$200(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;)Landroid/app/Activity;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;

    .prologue
    .line 15
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->activity:Landroid/app/Activity;

    return-object v0
.end method

.method static synthetic access$300(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;
    .param p1, "x1"    # Landroid/app/Activity;
    .param p2, "x2"    # Ljava/lang/String;
    .param p3, "x3"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    .prologue
    .line 15
    invoke-direct {p0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->alipay(Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V

    return-void
.end method

.method private alipay(Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V
    .locals 4
    .param p1, "activity"    # Landroid/app/Activity;
    .param p2, "payInfo"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    .prologue
    .line 100
    new-instance v0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;

    invoke-direct {v0, p0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$2;-><init>(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V

    .line 141
    .local v0, "task":Landroid/os/AsyncTask;, "Landroid/os/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    const/4 v1, 0x1

    new-array v2, v1, [Ljava/lang/Object;

    const/4 v3, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v2, v3

    invoke-virtual {v0, v2}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    .line 142
    return-void
.end method

.method private getOrderInfo(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 3
    .param p1, "subject"    # Ljava/lang/String;
    .param p2, "body"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;

    .prologue
    .line 150
    const-string v0, "partner=\"2088101137231227\""

    .line 153
    .local v0, "orderInfo":Ljava/lang/String;
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&seller_id=\"2088101137231227\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 156
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&out_trade_no=\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->getOutTradeNo()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 159
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&subject=\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 162
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&body=\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 165
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&total_fee=\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 168
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&notify_url=\"[NOTIFYURL]\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 171
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&service=\"mobile.securitypay.pay\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 174
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&payment_type=\"1\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 177
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&_input_charset=\"utf-8\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 184
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&it_b_pay=\"30m\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 190
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "&return_url=\"m.alipay.com\""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 195
    return-object v0
.end method

.method private getSignType()Ljava/lang/String;
    .locals 1

    .prologue
    .line 211
    const-string v0, "sign_type=\"RSA\""

    return-object v0
.end method


# virtual methods
.method public getOutTradeNo()Ljava/lang/String;
    .locals 1

    .prologue
    .line 203
    const-string v0, "[ORDERNO]"

    return-object v0
.end method

.method public getSDKVersion()Ljava/lang/String;
    .locals 3

    .prologue
    .line 219
    new-instance v0, Lcom/alipay/sdk/app/PayTask;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->activity:Landroid/app/Activity;

    invoke-direct {v0, v2}, Lcom/alipay/sdk/app/PayTask;-><init>(Landroid/app/Activity;)V

    .line 220
    .local v0, "payTask":Lcom/alipay/sdk/app/PayTask;
    invoke-virtual {v0}, Lcom/alipay/sdk/app/PayTask;->getVersion()Ljava/lang/String;

    move-result-object v1

    .line 221
    .local v1, "version":Ljava/lang/String;
    return-object v1
.end method

.method public pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;)V
    .locals 8
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "body"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;

    .prologue
    .line 54
    iget-boolean v0, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->isLocked:Z

    if-eqz v0, :cond_0

    .line 55
    const-string v0, "Alipay"

    const-string v1, "isLocked"

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 89
    :goto_0
    return-void

    .line 59
    :cond_0
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->isLocked:Z

    .line 61
    invoke-direct {p0, p2, p3, p4}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->getOrderInfo(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 62
    .local v6, "orderInfo":Ljava/lang/String;
    new-instance v0, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;->iggId:Ljava/lang/String;

    new-instance v7, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;

    invoke-direct {v7, p0, p6, v6}, Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$1;-><init>(Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper;Lcom/igg/iggsdkbusiness/Alipay/AlipayHelper$PayListener;Ljava/lang/String;)V

    move-object v2, p1

    move-object v3, p2

    move-object v4, p4

    move-object v5, p5

    invoke-virtual/range {v0 .. v7}, Lcom/igg/sdk/service/IGGPaymentService;->getAlipayOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;)V

    goto :goto_0
.end method
