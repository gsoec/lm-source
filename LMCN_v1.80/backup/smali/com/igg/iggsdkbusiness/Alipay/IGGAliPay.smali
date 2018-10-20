.class public Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;
.super Ljava/lang/Object;
.source "IGGAliPay.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;,
        Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;
    }
.end annotation


# static fields
.field private static final APP_ID:Ljava/lang/String; = "2016071901635842"

.field private static final TAG:Ljava/lang/String; = "IGGAliPay"


# instance fields
.field private IGGId:Ljava/lang/String;

.field private activity:Landroid/app/Activity;


# direct methods
.method public constructor <init>(Landroid/app/Activity;Ljava/lang/String;)V
    .locals 0
    .param p1, "activity"    # Landroid/app/Activity;
    .param p2, "IGGId"    # Ljava/lang/String;

    .prologue
    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 41
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->activity:Landroid/app/Activity;

    .line 42
    iput-object p2, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->IGGId:Ljava/lang/String;

    .line 43
    return-void
.end method

.method static synthetic access$000(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Ljava/lang/String;
    .param p3, "x3"    # Ljava/lang/String;
    .param p4, "x4"    # Ljava/lang/String;
    .param p5, "x5"    # Ljava/lang/String;
    .param p6, "x6"    # Ljava/lang/String;

    .prologue
    .line 32
    invoke-direct/range {p0 .. p6}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->getOrderInfo(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$100(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;)Landroid/app/Activity;
    .locals 1
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;

    .prologue
    .line 32
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->activity:Landroid/app/Activity;

    return-object v0
.end method

.method static synthetic access$200(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;
    .param p1, "x1"    # Landroid/app/Activity;
    .param p2, "x2"    # Ljava/lang/String;
    .param p3, "x3"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    .prologue
    .line 32
    invoke-direct {p0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->alipay(Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    return-void
.end method

.method private alipay(Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
    .locals 4
    .param p1, "activity"    # Landroid/app/Activity;
    .param p2, "payInfo"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    .prologue
    .line 108
    new-instance v0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;

    invoke-direct {v0, p0, p1, p2, p3}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$3;-><init>(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Landroid/app/Activity;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    .line 142
    .local v0, "task":Landroid/os/AsyncTask;, "Landroid/os/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    const/4 v1, 0x1

    new-array v2, v1, [Ljava/lang/Object;

    const/4 v3, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v2, v3

    invoke-virtual {v0, v2}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    .line 143
    return-void
.end method

.method private buildKeyValue(Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/String;
    .locals 3
    .param p1, "key"    # Ljava/lang/String;
    .param p2, "value"    # Ljava/lang/String;
    .param p3, "isEncode"    # Z

    .prologue
    .line 212
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    .line 213
    .local v1, "sb":Ljava/lang/StringBuilder;
    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 214
    const-string v2, "="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 215
    if-eqz p3, :cond_0

    .line 217
    :try_start_0
    const-string v2, "UTF-8"

    invoke-static {p2, v2}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    .line 224
    :goto_0
    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    return-object v2

    .line 218
    :catch_0
    move-exception v0

    .line 219
    .local v0, "e":Ljava/io/UnsupportedEncodingException;
    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0

    .line 222
    .end local v0    # "e":Ljava/io/UnsupportedEncodingException;
    :cond_0
    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0
.end method

.method private buildOrderParam(Ljava/util/Map;Z)Ljava/lang/String;
    .locals 8
    .param p2, "isEncode"    # Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;Z)",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    .line 192
    .local p1, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v2, Ljava/util/ArrayList;

    invoke-interface {p1}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v7

    invoke-direct {v2, v7}, Ljava/util/ArrayList;-><init>(Ljava/util/Collection;)V

    .line 194
    .local v2, "keys":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-static {v2}, Ljava/util/Collections;->sort(Ljava/util/List;)V

    .line 196
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    .line 197
    .local v3, "sb":Ljava/lang/StringBuilder;
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v7

    add-int/lit8 v7, v7, -0x1

    if-ge v0, v7, :cond_0

    .line 198
    invoke-interface {v2, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 199
    .local v1, "key":Ljava/lang/String;
    invoke-interface {p1, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    .line 200
    .local v6, "value":Ljava/lang/String;
    invoke-direct {p0, v1, v6, p2}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->buildKeyValue(Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 201
    const-string v7, "&"

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 197
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 204
    .end local v1    # "key":Ljava/lang/String;
    .end local v6    # "value":Ljava/lang/String;
    :cond_0
    invoke-interface {v2}, Ljava/util/List;->size()I

    move-result v7

    add-int/lit8 v7, v7, -0x1

    invoke-interface {v2, v7}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/String;

    .line 205
    .local v4, "tailKey":Ljava/lang/String;
    invoke-interface {p1, v4}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    .line 206
    .local v5, "tailValue":Ljava/lang/String;
    invoke-direct {p0, v4, v5, p2}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->buildKeyValue(Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 208
    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    return-object v7
.end method

.method private buildOrderParamMap(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/Map;
    .locals 4
    .param p1, "appId"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "body"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "outTradeNo"    # Ljava/lang/String;
    .param p6, "notifyUrl"    # Ljava/lang/String;
    .param p7, "timestamp"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 170
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 172
    .local v0, "keyValues":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "app_id"

    invoke-interface {v0, v1, p1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 174
    const-string v1, "biz_content"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "{\"timeout_express\":\"30m\",\"product_code\":\"QUICK_MSECURITY_PAY\",\"total_amount\":\""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "\",\"subject\":\""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "\",\"body\":\""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "\",\"out_trade_no\":\""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "\"}"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 176
    const-string v1, "charset"

    const-string v2, "utf-8"

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 178
    const-string v1, "method"

    const-string v2, "alipay.trade.app.pay"

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 180
    const-string v1, "timestamp"

    invoke-interface {v0, v1, p7}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 182
    const-string v1, "version"

    const-string v2, "1.0"

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 184
    const-string v1, "sign_type"

    const-string v2, "RSA"

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 186
    const-string v1, "notify_url"

    invoke-interface {v0, v1, p6}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 188
    return-object v0
.end method

.method private getNotifyUrl()Ljava/lang/String;
    .locals 1

    .prologue
    .line 166
    const-string v0, "[NOTIFYURL]"

    return-object v0
.end method

.method private getOrderInfo(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 10
    .param p1, "subject"    # Ljava/lang/String;
    .param p2, "body"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;
    .param p4, "outTradeNo"    # Ljava/lang/String;
    .param p5, "notifyUrl"    # Ljava/lang/String;
    .param p6, "timestamp"    # Ljava/lang/String;

    .prologue
    .line 154
    const-string v1, "2016071901635842"

    move-object v0, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move-object v6, p5

    move-object/from16 v7, p6

    invoke-direct/range {v0 .. v7}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->buildOrderParamMap(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/Map;

    move-result-object v9

    .line 156
    .local v9, "params":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const/4 v0, 0x1

    invoke-direct {p0, v9, v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->buildOrderParam(Ljava/util/Map;Z)Ljava/lang/String;

    move-result-object v8

    .line 158
    .local v8, "orderParam":Ljava/lang/String;
    return-object v8
.end method

.method private getOutTradeNo()Ljava/lang/String;
    .locals 1

    .prologue
    .line 162
    const-string v0, "[ORDERNO]"

    return-object v0
.end method

.method private getPreproccessOrderInfo(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 10
    .param p1, "subject"    # Ljava/lang/String;
    .param p2, "body"    # Ljava/lang/String;
    .param p3, "price"    # Ljava/lang/String;
    .param p4, "outTradeNo"    # Ljava/lang/String;
    .param p5, "notifyUrl"    # Ljava/lang/String;
    .param p6, "timestamp"    # Ljava/lang/String;

    .prologue
    .line 146
    const-string v1, "2016071901635842"

    move-object v0, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move-object v6, p5

    move-object/from16 v7, p6

    invoke-direct/range {v0 .. v7}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->buildOrderParamMap(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/Map;

    move-result-object v9

    .line 148
    .local v9, "preproccessParams":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    const/4 v0, 0x0

    invoke-direct {p0, v9, v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->buildOrderParam(Ljava/util/Map;Z)Ljava/lang/String;

    move-result-object v8

    .line 150
    .local v8, "preproccessOrderParam":Ljava/lang/String;
    return-object v8
.end method


# virtual methods
.method public pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V
    .locals 20
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "body"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;

    .prologue
    .line 48
    new-instance v18, Ljava/text/SimpleDateFormat;

    const-string v2, "yyyy-MM-dd HH:mm:ss"

    move-object/from16 v0, v18

    invoke-direct {v0, v2}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    .line 49
    .local v18, "formatter":Ljava/text/SimpleDateFormat;
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v2

    move-object/from16 v0, v18

    invoke-virtual {v0, v2}, Ljava/text/SimpleDateFormat;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v8

    .line 50
    .local v8, "timestamp":Ljava/lang/String;
    invoke-direct/range {p0 .. p0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->getOutTradeNo()Ljava/lang/String;

    move-result-object v6

    invoke-direct/range {p0 .. p0}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->getNotifyUrl()Ljava/lang/String;

    move-result-object v7

    move-object/from16 v2, p0

    move-object/from16 v3, p2

    move-object/from16 v4, p3

    move-object/from16 v5, p4

    invoke-direct/range {v2 .. v8}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->getPreproccessOrderInfo(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v19

    .line 51
    .local v19, "orderInfo":Ljava/lang/String;
    move-object/from16 v15, v19

    .line 54
    .local v15, "urlEncodeOrderInfo":Ljava/lang/String;
    :try_start_0
    const-string v2, "UTF-8"

    move-object/from16 v0, v19

    invoke-static {v0, v2}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v15

    .line 59
    :goto_0
    new-instance v9, Lcom/igg/sdk/service/IGGPaymentService;

    invoke-direct {v9}, Lcom/igg/sdk/service/IGGPaymentService;-><init>()V

    move-object/from16 v0, p0

    iget-object v10, v0, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->IGGId:Ljava/lang/String;

    new-instance v2, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;

    move-object/from16 v3, p0

    move-object/from16 v4, p6

    move-object/from16 v5, p2

    move-object/from16 v6, p3

    move-object/from16 v7, p4

    invoke-direct/range {v2 .. v8}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$1;-><init>(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    move-object/from16 v11, p1

    move-object/from16 v12, p2

    move-object/from16 v13, p4

    move-object/from16 v14, p5

    move-object/from16 v16, v2

    invoke-virtual/range {v9 .. v16}, Lcom/igg/sdk/service/IGGPaymentService;->getAlipayOrder(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGPaymentService$PaymentOrdersNoListener;)V

    .line 81
    return-void

    .line 55
    :catch_0
    move-exception v17

    .line 56
    .local v17, "e":Ljava/io/UnsupportedEncodingException;
    invoke-virtual/range {v17 .. v17}, Ljava/io/UnsupportedEncodingException;->printStackTrace()V

    goto :goto_0
.end method

.method public pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;)V
    .locals 12
    .param p1, "itemId"    # Ljava/lang/String;
    .param p2, "subject"    # Ljava/lang/String;
    .param p3, "body"    # Ljava/lang/String;
    .param p4, "price"    # Ljava/lang/String;
    .param p5, "quantity"    # Ljava/lang/String;
    .param p6, "restriction"    # Lcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;
    .param p7, "listener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;
    .param p8, "amoutOfLimitListener"    # Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;

    .prologue
    .line 83
    if-nez p6, :cond_0

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object/from16 v5, p4

    move-object/from16 v6, p5

    move-object/from16 v7, p7

    .line 84
    invoke-virtual/range {v1 .. v7}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;->pay(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    .line 105
    :goto_0
    return-void

    .line 87
    :cond_0
    invoke-static {p1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v10

    .line 88
    .local v10, "id":I
    new-instance v11, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v2}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v2

    move-object/from16 v0, p6

    invoke-direct {v11, v1, v2, v10, v0}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;-><init>(Ljava/lang/String;Ljava/lang/String;ILcom/igg/sdk/payment/bean/IGGPaymentPurchaseRestriction;)V

    .line 89
    .local v11, "processor":Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;
    new-instance v1, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;

    move-object v2, p0

    move-object/from16 v3, p8

    move-object v4, p1

    move-object v5, p2

    move-object v6, p3

    move-object/from16 v7, p4

    move-object/from16 v8, p5

    move-object/from16 v9, p7

    invoke-direct/range {v1 .. v9}, Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$2;-><init>(Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$AmoutOfLimitListener;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/iggsdkbusiness/Alipay/IGGAliPay$PayListener;)V

    invoke-virtual {v11, v1}, Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor;->process(Lcom/igg/iggsdkbusiness/Alipay/IGGPaymentPurchaseRestrictionProcessor$IGGPaymentPurchaseRestrictionProcessResultListener;)V

    goto :goto_0
.end method
