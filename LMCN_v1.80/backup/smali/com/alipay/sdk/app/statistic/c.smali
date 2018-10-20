.class public final Lcom/alipay/sdk/app/statistic/c;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final A:Ljava/lang/String; = "BindWaitTimeoutEx"

.field public static final B:Ljava/lang/String; = "CheckClientExistEx"

.field public static final C:Ljava/lang/String; = "CheckClientSignEx"

.field public static final D:Ljava/lang/String; = "GetInstalledAppEx"

.field public static final E:Ljava/lang/String; = "GetInstalledAppEx"

.field public static final F:Ljava/lang/String; = "partner"

.field public static final G:Ljava/lang/String; = "out_trade_no"

.field public static final H:Ljava/lang/String; = "trade_no"

.field public static final a:Ljava/lang/String; = "net"

.field public static final b:Ljava/lang/String; = "biz"

.field public static final c:Ljava/lang/String; = "cp"

.field public static final d:Ljava/lang/String; = "auth"

.field public static final e:Ljava/lang/String; = "third"

.field public static final f:Ljava/lang/String; = "FormatResultEx"

.field public static final g:Ljava/lang/String; = "GetApdidEx"

.field public static final h:Ljava/lang/String; = "GetApdidNull"

.field public static final i:Ljava/lang/String; = "GetApdidTimeout"

.field public static final j:Ljava/lang/String; = "GetUtdidEx"

.field public static final k:Ljava/lang/String; = "GetPackageInfoEx"

.field public static final l:Ljava/lang/String; = "NotIncludeSignatures"

.field public static final m:Ljava/lang/String; = "GetInstalledPackagesEx"

.field public static final n:Ljava/lang/String; = "GetPublicKeyFromSignEx"

.field public static final o:Ljava/lang/String; = "H5PayNetworkError"

.field public static final p:Ljava/lang/String; = "H5AuthNetworkError"

.field public static final q:Ljava/lang/String; = "SSLError"

.field public static final r:Ljava/lang/String; = "H5PayDataAnalysisError"

.field public static final s:Ljava/lang/String; = "H5AuthDataAnalysisError"

.field public static final t:Ljava/lang/String; = "PublicKeyUnmatch"

.field public static final u:Ljava/lang/String; = "ClientBindFailed"

.field public static final v:Ljava/lang/String; = "TriDesEncryptError"

.field public static final w:Ljava/lang/String; = "TriDesDecryptError"

.field public static final x:Ljava/lang/String; = "ClientBindException"

.field public static final y:Ljava/lang/String; = "SaveTradeTokenError"

.field public static final z:Ljava/lang/String; = "ClientBindServiceFailed"


# instance fields
.field I:Ljava/lang/String;

.field J:Ljava/lang/String;

.field K:Ljava/lang/String;

.field L:Ljava/lang/String;

.field M:Ljava/lang/String;

.field N:Ljava/lang/String;

.field O:Ljava/lang/String;

.field P:Ljava/lang/String;

.field Q:Ljava/lang/String;

.field R:Ljava/lang/String;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 14

    .prologue
    const/4 v13, 0x2

    const/4 v12, 0x1

    const/4 v11, 0x0

    .line 85
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 81
    const-string v0, ""

    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    .line 1165
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd-HH:mm:ss"

    invoke-direct {v0, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    .line 1166
    new-instance v1, Ljava/util/Date;

    invoke-direct {v1}, Ljava/util/Date;-><init>()V

    invoke-virtual {v0, v1}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v0

    .line 1167
    const-string v1, "123456789,%s"

    new-array v2, v12, [Ljava/lang/Object;

    aput-object v0, v2, v11

    invoke-static {v1, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 86
    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->I:Ljava/lang/String;

    .line 87
    invoke-static {p1}, Lcom/alipay/sdk/app/statistic/c;->a(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->K:Ljava/lang/String;

    .line 1217
    const-string v0, "15.4.0"

    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1218
    const-string v1, "h.a.3.4.0"

    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 1221
    const-string v2, "android,3,%s,%s,com.alipay.mcpay,5.0,-,-,-"

    new-array v3, v13, [Ljava/lang/Object;

    aput-object v0, v3, v11

    aput-object v1, v3, v12

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 88
    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->L:Ljava/lang/String;

    .line 1227
    invoke-static {}, Lcom/alipay/sdk/tid/b;->a()Lcom/alipay/sdk/tid/b;

    move-result-object v0

    .line 2031
    iget-object v0, v0, Lcom/alipay/sdk/tid/b;->a:Ljava/lang/String;

    .line 1227
    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1228
    invoke-static {}, Lcom/alipay/sdk/sys/b;->a()Lcom/alipay/sdk/sys/b;

    move-result-object v1

    invoke-virtual {v1}, Lcom/alipay/sdk/sys/b;->c()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 1229
    const-string v2, "%s,%s,-,-,-"

    new-array v3, v13, [Ljava/lang/Object;

    aput-object v0, v3, v11

    aput-object v1, v3, v12

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 89
    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->M:Ljava/lang/String;

    .line 2234
    invoke-static {p1}, Lcom/alipay/sdk/util/a;->d(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 2235
    const-string v1, "android"

    .line 2236
    sget-object v2, Landroid/os/Build$VERSION;->RELEASE:Ljava/lang/String;

    invoke-static {v2}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 2237
    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-static {v3}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 2238
    const-string v4, "-"

    .line 2239
    invoke-static {p1}, Lcom/alipay/sdk/util/a;->a(Landroid/content/Context;)Lcom/alipay/sdk/util/a;

    move-result-object v5

    invoke-virtual {v5}, Lcom/alipay/sdk/util/a;->a()Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 2240
    invoke-static {p1}, Lcom/alipay/sdk/util/a;->b(Landroid/content/Context;)Lcom/alipay/sdk/util/d;

    move-result-object v6

    .line 3060
    iget-object v6, v6, Lcom/alipay/sdk/util/d;->p:Ljava/lang/String;

    .line 2240
    invoke-static {v6}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 2241
    const-string v7, "gw"

    .line 2242
    invoke-static {p1}, Lcom/alipay/sdk/util/a;->a(Landroid/content/Context;)Lcom/alipay/sdk/util/a;

    move-result-object v8

    invoke-virtual {v8}, Lcom/alipay/sdk/util/a;->b()Ljava/lang/String;

    move-result-object v8

    invoke-static {v8}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    .line 2243
    const-string v9, "%s,%s,%s,%s,%s,%s,%s,%s,%s,-"

    const/16 v10, 0x9

    new-array v10, v10, [Ljava/lang/Object;

    aput-object v0, v10, v11

    aput-object v1, v10, v12

    aput-object v2, v10, v13

    const/4 v0, 0x3

    aput-object v3, v10, v0

    const/4 v0, 0x4

    aput-object v4, v10, v0

    const/4 v0, 0x5

    aput-object v5, v10, v0

    const/4 v0, 0x6

    aput-object v6, v10, v0

    const/4 v0, 0x7

    aput-object v7, v10, v0

    const/16 v0, 0x8

    aput-object v8, v10, v0

    invoke-static {v9, v10}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 90
    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->N:Ljava/lang/String;

    .line 91
    const-string v0, "-"

    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->O:Ljava/lang/String;

    .line 92
    const-string v0, "-"

    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->P:Ljava/lang/String;

    .line 93
    const-string v0, "-"

    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->R:Ljava/lang/String;

    .line 94
    return-void
.end method

.method private static a(Landroid/content/Context;)Ljava/lang/String;
    .locals 5

    .prologue
    const/4 v4, 0x0

    .line 199
    const-string v1, "-"

    .line 200
    const-string v0, "-"

    .line 202
    if-eqz p0, :cond_0

    .line 204
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v2

    .line 205
    invoke-virtual {v2}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v1

    .line 206
    invoke-virtual {v2}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v2

    .line 207
    const/4 v3, 0x0

    invoke-virtual {v2, v1, v3}, Landroid/content/pm/PackageManager;->getPackageInfo(Ljava/lang/String;I)Landroid/content/pm/PackageInfo;

    move-result-object v2

    .line 208
    iget-object v0, v2, Landroid/content/pm/PackageInfo;->versionName:Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 212
    :cond_0
    :goto_0
    const-string v2, "%s,%s,-,-,-"

    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/Object;

    aput-object v1, v3, v4

    const/4 v1, 0x1

    aput-object v0, v3, v1

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0

    :catch_0
    move-exception v2

    goto :goto_0
.end method

.method static a(Ljava/lang/String;)Ljava/lang/String;
    .locals 3

    .prologue
    .line 124
    invoke-static {p0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 125
    const-string v0, ""

    .line 128
    :goto_0
    return-object v0

    :cond_0
    const-string v0, "["

    const-string v1, "\u3010"

    invoke-virtual {p0, v0, v1}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "]"

    const-string v2, "\u3011"

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "("

    const-string v2, "\uff08"

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    const-string v1, ")"

    const-string v2, "\uff09"

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    const-string v1, ","

    const-string v2, "\uff0c"

    .line 129
    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "-"

    const-string v2, "="

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "^"

    const-string v2, "~"

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method static a(Ljava/lang/Throwable;)Ljava/lang/String;
    .locals 5

    .prologue
    .line 133
    if-nez p0, :cond_0

    .line 134
    const-string v0, ""

    .line 150
    :goto_0
    return-object v0

    .line 137
    :cond_0
    new-instance v1, Ljava/lang/StringBuffer;

    invoke-direct {v1}, Ljava/lang/StringBuffer;-><init>()V

    .line 139
    :try_start_0
    invoke-virtual {p0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    move-result-object v0

    const-string v2, ":"

    invoke-virtual {v0, v2}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 140
    invoke-virtual {p0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 141
    const-string v0, " \u300b "

    invoke-virtual {v1, v0}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 142
    invoke-virtual {p0}, Ljava/lang/Throwable;->getStackTrace()[Ljava/lang/StackTraceElement;

    move-result-object v2

    .line 143
    if-eqz v2, :cond_1

    .line 144
    const/4 v0, 0x0

    :goto_1
    array-length v3, v2

    if-ge v0, v3, :cond_1

    .line 145
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    aget-object v4, v2, v0

    invoke-virtual {v4}, Ljava/lang/StackTraceElement;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, " \u300b "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 144
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :catch_0
    move-exception v0

    .line 150
    :cond_1
    invoke-virtual {v1}, Ljava/lang/StringBuffer;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method private a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 106
    invoke-static {p3}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object v0

    .line 107
    invoke-virtual {p0, p1, p2, v0, p4}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 108
    return-void
.end method

.method private a()Z
    .locals 1

    .prologue
    .line 97
    iget-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    return v0
.end method

.method private static b()Ljava/lang/String;
    .locals 4
    .annotation build Landroid/annotation/SuppressLint;
        value = {
            "SimpleDateFormat"
        }
    .end annotation

    .prologue
    .line 165
    new-instance v0, Ljava/text/SimpleDateFormat;

    const-string v1, "yyyy-MM-dd-HH:mm:ss"

    invoke-direct {v0, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;)V

    .line 166
    new-instance v1, Ljava/util/Date;

    invoke-direct {v1}, Ljava/util/Date;-><init>()V

    invoke-virtual {v0, v1}, Ljava/text/SimpleDateFormat;->format(Ljava/util/Date;)Ljava/lang/String;

    move-result-object v0

    .line 167
    const-string v1, "123456789,%s"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/Object;

    const/4 v3, 0x0

    aput-object v0, v2, v3

    invoke-static {v1, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private static b(Landroid/content/Context;)Ljava/lang/String;
    .locals 12

    .prologue
    .line 234
    invoke-static {p0}, Lcom/alipay/sdk/util/a;->d(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 235
    const-string v1, "android"

    .line 236
    sget-object v2, Landroid/os/Build$VERSION;->RELEASE:Ljava/lang/String;

    invoke-static {v2}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 237
    sget-object v3, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-static {v3}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    .line 238
    const-string v4, "-"

    .line 239
    invoke-static {p0}, Lcom/alipay/sdk/util/a;->a(Landroid/content/Context;)Lcom/alipay/sdk/util/a;

    move-result-object v5

    invoke-virtual {v5}, Lcom/alipay/sdk/util/a;->a()Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 240
    invoke-static {p0}, Lcom/alipay/sdk/util/a;->b(Landroid/content/Context;)Lcom/alipay/sdk/util/d;

    move-result-object v6

    .line 4060
    iget-object v6, v6, Lcom/alipay/sdk/util/d;->p:Ljava/lang/String;

    .line 240
    invoke-static {v6}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v6

    .line 241
    const-string v7, "gw"

    .line 242
    invoke-static {p0}, Lcom/alipay/sdk/util/a;->a(Landroid/content/Context;)Lcom/alipay/sdk/util/a;

    move-result-object v8

    invoke-virtual {v8}, Lcom/alipay/sdk/util/a;->b()Ljava/lang/String;

    move-result-object v8

    invoke-static {v8}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    .line 243
    const-string v9, "%s,%s,%s,%s,%s,%s,%s,%s,%s,-"

    const/16 v10, 0x9

    new-array v10, v10, [Ljava/lang/Object;

    const/4 v11, 0x0

    aput-object v0, v10, v11

    const/4 v0, 0x1

    aput-object v1, v10, v0

    const/4 v0, 0x2

    aput-object v2, v10, v0

    const/4 v0, 0x3

    aput-object v3, v10, v0

    const/4 v0, 0x4

    aput-object v4, v10, v0

    const/4 v0, 0x5

    aput-object v5, v10, v0

    const/4 v0, 0x6

    aput-object v6, v10, v0

    const/4 v0, 0x7

    aput-object v7, v10, v0

    const/16 v0, 0x8

    aput-object v8, v10, v0

    invoke-static {v9, v10}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private b(Ljava/lang/String;)Ljava/lang/String;
    .locals 12

    .prologue
    const/4 v0, 0x0

    const/4 v11, 0x3

    const/4 v10, 0x2

    const/4 v9, 0x1

    const/4 v3, 0x0

    .line 154
    .line 3097
    iget-object v1, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    invoke-static {v1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    .line 154
    if-eqz v1, :cond_0

    .line 155
    const-string v0, ""

    .line 158
    :goto_0
    return-object v0

    .line 3176
    :cond_0
    const-string v1, "&"

    invoke-virtual {p1, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v4

    .line 3177
    if-eqz v4, :cond_4

    .line 3178
    array-length v5, v4

    move v2, v3

    move-object v1, v0

    :goto_1
    if-ge v2, v5, :cond_5

    aget-object v6, v4, v2

    .line 3179
    const-string v7, "="

    invoke-virtual {v6, v7}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v6

    .line 3180
    if-eqz v6, :cond_1

    array-length v7, v6

    if-ne v7, v10, :cond_1

    .line 3181
    aget-object v7, v6, v3

    const-string v8, "partner"

    invoke-virtual {v7, v8}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_2

    .line 3182
    aget-object v6, v6, v9

    const-string v7, "\""

    const-string v8, ""

    invoke-virtual {v6, v7, v8}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    .line 3178
    :cond_1
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 3183
    :cond_2
    aget-object v7, v6, v3

    const-string v8, "out_trade_no"

    invoke-virtual {v7, v8}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_3

    .line 3184
    aget-object v1, v6, v9

    const-string v6, "\""

    const-string v7, ""

    invoke-virtual {v1, v6, v7}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v1

    goto :goto_2

    .line 3185
    :cond_3
    aget-object v7, v6, v3

    const-string v8, "trade_no"

    invoke-virtual {v7, v8}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1

    .line 3186
    aget-object v0, v6, v9

    const-string v6, "\""

    const-string v7, ""

    invoke-virtual {v0, v6, v7}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    goto :goto_2

    :cond_4
    move-object v1, v0

    .line 3191
    :cond_5
    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 3192
    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 3193
    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 3194
    const-string v4, "%s,%s,-,%s,-,-,-"

    new-array v5, v11, [Ljava/lang/Object;

    aput-object v0, v5, v3

    aput-object v1, v5, v9

    aput-object v2, v5, v10

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 157
    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->J:Ljava/lang/String;

    .line 158
    const-string v0, "[(%s),(%s),(%s),(%s),(%s),(%s),(%s),(%s),(%s),(%s)]"

    const/16 v1, 0xa

    new-array v1, v1, [Ljava/lang/Object;

    iget-object v2, p0, Lcom/alipay/sdk/app/statistic/c;->I:Ljava/lang/String;

    aput-object v2, v1, v3

    iget-object v2, p0, Lcom/alipay/sdk/app/statistic/c;->J:Ljava/lang/String;

    aput-object v2, v1, v9

    iget-object v2, p0, Lcom/alipay/sdk/app/statistic/c;->K:Ljava/lang/String;

    aput-object v2, v1, v10

    iget-object v2, p0, Lcom/alipay/sdk/app/statistic/c;->L:Ljava/lang/String;

    aput-object v2, v1, v11

    const/4 v2, 0x4

    iget-object v3, p0, Lcom/alipay/sdk/app/statistic/c;->M:Ljava/lang/String;

    aput-object v3, v1, v2

    const/4 v2, 0x5

    iget-object v3, p0, Lcom/alipay/sdk/app/statistic/c;->N:Ljava/lang/String;

    aput-object v3, v1, v2

    const/4 v2, 0x6

    iget-object v3, p0, Lcom/alipay/sdk/app/statistic/c;->O:Ljava/lang/String;

    aput-object v3, v1, v2

    const/4 v2, 0x7

    iget-object v3, p0, Lcom/alipay/sdk/app/statistic/c;->P:Ljava/lang/String;

    aput-object v3, v1, v2

    const/16 v2, 0x8

    iget-object v3, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    aput-object v3, v1, v2

    const/16 v2, 0x9

    iget-object v3, p0, Lcom/alipay/sdk/app/statistic/c;->R:Ljava/lang/String;

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    goto/16 :goto_0
.end method

.method private static c()Ljava/lang/String;
    .locals 5

    .prologue
    .line 217
    const-string v0, "15.4.0"

    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 218
    const-string v1, "h.a.3.4.0"

    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 221
    const-string v2, "android,3,%s,%s,com.alipay.mcpay,5.0,-,-,-"

    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object v0, v3, v4

    const/4 v0, 0x1

    aput-object v1, v3, v0

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private static c(Ljava/lang/String;)Ljava/lang/String;
    .locals 11

    .prologue
    const/4 v0, 0x0

    const/4 v10, 0x2

    const/4 v9, 0x1

    const/4 v3, 0x0

    .line 173
    .line 176
    const-string v1, "&"

    invoke-virtual {p0, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v4

    .line 177
    if-eqz v4, :cond_3

    .line 178
    array-length v5, v4

    move v2, v3

    move-object v1, v0

    :goto_0
    if-ge v2, v5, :cond_4

    aget-object v6, v4, v2

    .line 179
    const-string v7, "="

    invoke-virtual {v6, v7}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v6

    .line 180
    if-eqz v6, :cond_0

    array-length v7, v6

    if-ne v7, v10, :cond_0

    .line 181
    aget-object v7, v6, v3

    const-string v8, "partner"

    invoke-virtual {v7, v8}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_1

    .line 182
    aget-object v6, v6, v9

    const-string v7, "\""

    const-string v8, ""

    invoke-virtual {v6, v7, v8}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    .line 178
    :cond_0
    :goto_1
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    .line 183
    :cond_1
    aget-object v7, v6, v3

    const-string v8, "out_trade_no"

    invoke-virtual {v7, v8}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_2

    .line 184
    aget-object v1, v6, v9

    const-string v6, "\""

    const-string v7, ""

    invoke-virtual {v1, v6, v7}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v1

    goto :goto_1

    .line 185
    :cond_2
    aget-object v7, v6, v3

    const-string v8, "trade_no"

    invoke-virtual {v7, v8}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v7

    if-eqz v7, :cond_0

    .line 186
    aget-object v0, v6, v9

    const-string v6, "\""

    const-string v7, ""

    invoke-virtual {v0, v6, v7}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    goto :goto_1

    :cond_3
    move-object v1, v0

    .line 191
    :cond_4
    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 192
    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 193
    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 194
    const-string v4, "%s,%s,-,%s,-,-,-"

    const/4 v5, 0x3

    new-array v5, v5, [Ljava/lang/Object;

    aput-object v0, v5, v3

    aput-object v1, v5, v9

    aput-object v2, v5, v10

    invoke-static {v4, v5}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private static d()Ljava/lang/String;
    .locals 5

    .prologue
    .line 227
    invoke-static {}, Lcom/alipay/sdk/tid/b;->a()Lcom/alipay/sdk/tid/b;

    move-result-object v0

    .line 4031
    iget-object v0, v0, Lcom/alipay/sdk/tid/b;->a:Ljava/lang/String;

    .line 227
    invoke-static {v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 228
    invoke-static {}, Lcom/alipay/sdk/sys/b;->a()Lcom/alipay/sdk/sys/b;

    move-result-object v1

    invoke-virtual {v1}, Lcom/alipay/sdk/sys/b;->c()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 229
    const-string v2, "%s,%s,-,-,-"

    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object v0, v3, v4

    const/4 v0, 0x1

    aput-object v1, v3, v0

    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public final a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 120
    const-string v0, "-"

    invoke-virtual {p0, p1, p2, p3, v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 121
    return-void
.end method

.method public final a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 5

    .prologue
    .line 111
    const-string v0, ""

    .line 112
    iget-object v1, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    invoke-static {v1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 113
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "^"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 115
    :cond_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "%s,%s,%s,%s"

    const/4 v2, 0x4

    new-array v2, v2, [Ljava/lang/Object;

    const/4 v3, 0x0

    aput-object p1, v2, v3

    const/4 v3, 0x1

    aput-object p2, v2, v3

    const/4 v3, 0x2

    invoke-static {p3}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    aput-object v4, v2, v3

    const/4 v3, 0x3

    aput-object p4, v2, v3

    invoke-static {v1, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 116
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/alipay/sdk/app/statistic/c;->Q:Ljava/lang/String;

    .line 117
    return-void
.end method

.method public final a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 1

    .prologue
    .line 101
    invoke-static {p3}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/Throwable;)Ljava/lang/String;

    move-result-object v0

    .line 102
    invoke-virtual {p0, p1, p2, v0}, Lcom/alipay/sdk/app/statistic/c;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 103
    return-void
.end method
