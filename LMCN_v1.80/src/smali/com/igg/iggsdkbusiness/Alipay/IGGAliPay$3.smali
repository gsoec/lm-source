.class Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;
.super Landroid/os/AsyncTask;
.source "IGGAliPay.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->alipay(Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Object;",
        "Ljava/lang/Integer;",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

.field final synthetic val$activity:Landroid/app/Activity;

.field final synthetic val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

.field final synthetic val$payInfo:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    .prologue
    .line 108
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->this$0:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$activity:Landroid/app/Activity;

    iput-object p3, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$payInfo:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 5
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 113
    new-instance v0, Lcom/alipay/sdk/app/PayTask;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$activity:Landroid/app/Activity;

    invoke-direct {v0, v2}, Lcom/alipay/sdk/app/PayTask;-><init>(Landroid/app/Activity;)V

    .line 115
    .local v0, "alipay":Lcom/alipay/sdk/app/PayTask;
    iget-object v2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$payInfo:Ljava/lang/String;

    const/4 v3, 0x1

    invoke-virtual {v0, v2, v3}, Lcom/alipay/sdk/app/PayTask;->payV2(Ljava/lang/String;Z)Ljava/util/Map;

    move-result-object v1

    .line 116
    .local v1, "result":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "IGGAliPay"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "resultInfo:"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 117
    return-object v1
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 5
    .param p1, "map"    # Ljava/lang/Object;

    .prologue
    .line 122
    move-object v0, p1

    check-cast v0, Ljava/util/Map;

    .line 123
    .local v0, "hashMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v4, "result"

    invoke-interface {v0, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 124
    .local v2, "result":Ljava/lang/String;
    new-instance v1, Lcom/igg/iggsdkbusiness/Alipay/PayResult;

    invoke-direct {v1, v2}, Lcom/igg/iggsdkbusiness/Alipay/PayResult;-><init>(Ljava/lang/String;)V

    .line 125
    .local v1, "payResult":Lcom/igg/iggsdkbusiness/Alipay/PayResult;
    invoke-virtual {v1}, Lcom/igg/iggsdkbusiness/Alipay/PayResult;->getResultStatus()Ljava/lang/String;

    move-result-object v3

    .line 127
    .local v3, "resultStatus":Ljava/lang/String;
    const-string v4, "9000"

    invoke-static {v3, v4}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_0

    .line 128
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-interface {v4, v1}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;->onSuccess(Lcom/igg/iggsdkbusiness/Alipay/PayResult;)V

    .line 139
    :goto_0
    return-void

    .line 132
    :cond_0
    const-string v4, "8000"

    invoke-static {v3, v4}, Landroid/text/TextUtils;->equals(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Z

    move-result v4

    if-eqz v4, :cond_1

    .line 133
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-interface {v4}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;->onWaitResult()V

    goto :goto_0

    .line 136
    :cond_1
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;->val$listener:Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    invoke-interface {v4}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;->onError()V

    goto :goto_0
.end method
