.class public Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;
.super Ljava/lang/Object;
.source "IGGAdwordsEventReporter.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;,
        Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;
    }
.end annotation


# static fields
.field private static final INSERT_FAILED:I = -0xa

.field private static final MISSING_DEVICE_ID:I = -0x2

.field private static final MISSING_GAME_ID:I = -0x1

.field private static final TAG:Ljava/lang/String; = "IGGAdwordsEventReporter"


# instance fields
.field private IDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field private proxy:Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 1
    .param p1, "IDC"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    iput-object p1, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->IDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 47
    new-instance v0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatDefaultProxy;

    invoke-direct {v0}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatDefaultProxy;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->proxy:Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;

    .line 48
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;I)Lcom/igg/sdk/error/IGGException;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;
    .param p1, "x1"    # I

    .prologue
    .line 36
    invoke-direct {p0, p1}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->exceptionWithError(I)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    .prologue
    .line 36
    invoke-direct {p0}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->getMuId()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$200(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;)Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    .prologue
    .line 36
    iget-object v0, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->IDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method

.method private exceptionWithError(I)Lcom/igg/sdk/error/IGGException;
    .locals 4
    .param p1, "errorCode"    # I

    .prologue
    .line 154
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v1

    .line 155
    .local v1, "underlyingException":Lcom/igg/sdk/error/IGGException;
    const/4 v0, 0x0

    .line 156
    .local v0, "exception":Lcom/igg/sdk/error/IGGException;
    sparse-switch p1, :sswitch_data_0

    .line 182
    const-string v2, "2091011000"

    const-string v3, "10"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 186
    :goto_0
    return-object v0

    .line 158
    :sswitch_0
    const-string v2, "2091011001"

    const-string v3, "32"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 159
    goto :goto_0

    .line 162
    :sswitch_1
    const-string v2, "2091011002"

    const-string v3, "20"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 163
    goto :goto_0

    .line 166
    :sswitch_2
    const-string v2, "2091011003"

    const-string v3, "20"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 167
    goto :goto_0

    .line 170
    :sswitch_3
    const-string v2, "2091011006"

    const-string v3, "10"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 171
    goto :goto_0

    .line 174
    :sswitch_4
    const-string v2, "2091011007"

    const-string v3, "10"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 175
    goto :goto_0

    .line 178
    :sswitch_5
    const-string v2, "2091011008"

    const-string v3, "10"

    invoke-static {v2, v3}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/igg/sdk/error/IGGException;->underlyingException(Lcom/igg/sdk/error/IGGException;)Lcom/igg/sdk/error/IGGException;

    move-result-object v0

    .line 179
    goto :goto_0

    .line 156
    :sswitch_data_0
    .sparse-switch
        -0xa -> :sswitch_5
        -0x2 -> :sswitch_4
        -0x1 -> :sswitch_3
        0x190 -> :sswitch_0
        0x1f4 -> :sswitch_1
        0x1f5 -> :sswitch_2
    .end sparse-switch
.end method

.method private getMuId()Ljava/lang/String;
    .locals 7

    .prologue
    const/4 v4, 0x0

    .line 196
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v5

    invoke-virtual {v5}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v5

    invoke-static {v5}, Lcom/igg/util/DeviceUtil;->getAndroidId(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    .line 198
    .local v0, "androidID":Ljava/lang/String;
    :try_start_0
    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v5

    if-eqz v5, :cond_0

    .line 208
    :goto_0
    return-object v4

    .line 202
    :cond_0
    const-string v5, "MD5"

    invoke-static {v5}, Ljava/security/MessageDigest;->getInstance(Ljava/lang/String;)Ljava/security/MessageDigest;

    move-result-object v3

    .line 203
    .local v3, "messageDigest":Ljava/security/MessageDigest;
    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    .line 204
    .local v2, "inputByteArray":[B
    invoke-virtual {v3, v2}, Ljava/security/MessageDigest;->update([B)V

    .line 205
    invoke-virtual {v3}, Ljava/security/MessageDigest;->digest()[B

    move-result-object v5

    const/16 v6, 0xb

    invoke-static {v5, v6}, Landroid/util/Base64;->encodeToString([BI)Ljava/lang/String;
    :try_end_0
    .catch Ljava/security/NoSuchAlgorithmException; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v4

    .line 206
    .local v4, "result":Ljava/lang/String;
    goto :goto_0

    .line 207
    .end local v2    # "inputByteArray":[B
    .end local v3    # "messageDigest":Ljava/security/MessageDigest;
    .end local v4    # "result":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 208
    .local v1, "e":Ljava/security/NoSuchAlgorithmException;
    goto :goto_0
.end method

.method private report(Ljava/util/HashMap;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
    .locals 4
    .param p2, "listener"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 94
    .local p1, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "IGGAdwordsEventReporter"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "event_type = "

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v1, "event_type"

    invoke-virtual {p1, v1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v2, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 95
    const-string v1, "gid"

    iget-object v2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->proxy:Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;

    invoke-interface {v2}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 96
    const-string v1, "step"

    const-string v2, "1"

    invoke-virtual {p1, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 97
    const-string v1, "IGGAdwordsEventReporter"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "params = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p1}, Ljava/util/HashMap;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 98
    new-instance v0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;

    invoke-direct {v0, p0, p2}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;-><init>(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V

    .line 127
    .local v0, "requestListener":Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    new-instance v1, Ljava/lang/Thread;

    new-instance v2, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;

    invoke-direct {v2, p0, p1, v0}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;-><init>(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    invoke-direct {v1, v2}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 150
    invoke-virtual {v1}, Ljava/lang/Thread;->start()V

    .line 151
    return-void
.end method


# virtual methods
.method public changeAdwordsEventReporterCompatProxy(Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;)V
    .locals 0
    .param p1, "proxy"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;

    .prologue
    .line 59
    iput-object p1, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->proxy:Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;

    .line 60
    return-void
.end method

.method public getAdwordsEventReporterCompatProxy()Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;
    .locals 1

    .prologue
    .line 55
    iget-object v0, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->proxy:Lcom/igg/sdk/marketing/IGGAdwordsEventReporterCompatProxy;

    return-object v0
.end method

.method public reportInstallation(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
    .locals 3
    .param p1, "listener"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;

    .prologue
    .line 67
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 68
    .local v0, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "event_type"

    sget-object v2, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;->INSTALL:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;

    invoke-virtual {v2}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;->getStringValue()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 69
    invoke-direct {p0, v0, p1}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->report(Ljava/util/HashMap;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V

    .line 70
    return-void
.end method

.method public reportSigningUp(Ljava/lang/String;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
    .locals 3
    .param p1, "IGGId"    # Ljava/lang/String;
    .param p2, "listener"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 79
    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 80
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "IGGId Can not be empty"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 83
    :cond_0
    invoke-static {p1}, Landroid/text/TextUtils;->isDigitsOnly(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_1

    .line 84
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "IGGId must be a numeric type"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 87
    :cond_1
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 88
    .local v0, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "event_type"

    sget-object v2, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;->SIGNUP:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;

    invoke-virtual {v2}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventType;->getStringValue()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 89
    const-string v1, "iggid"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 90
    invoke-direct {p0, v0, p2}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->report(Ljava/util/HashMap;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V

    .line 91
    return-void
.end method
