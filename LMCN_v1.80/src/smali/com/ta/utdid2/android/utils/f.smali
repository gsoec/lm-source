.class public final Lcom/ta/utdid2/android/utils/f;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final a:Ljava/lang/String; = "Wi-Fi"

.field public static final b:Ljava/lang/String; = "00-00-00-00-00-00"

.field private static final c:Ljava/lang/String; = "NetworkUtils"

.field private static d:Landroid/net/ConnectivityManager;

.field private static final e:[I


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 22
    const/4 v0, 0x0

    sput-object v0, Lcom/ta/utdid2/android/utils/f;->d:Landroid/net/ConnectivityManager;

    .line 24
    const/4 v0, 0x4

    new-array v0, v0, [I

    fill-array-data v0, :array_0

    sput-object v0, Lcom/ta/utdid2/android/utils/f;->e:[I

    .line 29
    return-void

    .line 24
    :array_0
    .array-data 4
        0x4
        0x7
        0x2
        0x1
    .end array-data
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 17
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static a(I)Ljava/lang/String;
    .locals 2

    .prologue
    .line 145
    new-instance v0, Ljava/lang/StringBuilder;

    and-int/lit16 v1, p0, 0xff

    invoke-static {v1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v1, "."

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    shr-int/lit8 v1, p0, 0x8

    and-int/lit16 v1, v1, 0xff

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "."

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    shr-int/lit8 v1, p0, 0x10

    and-int/lit16 v1, v1, 0xff

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 146
    const-string v1, "."

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    shr-int/lit8 v1, p0, 0x18

    and-int/lit16 v1, v1, 0xff

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 145
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public static a(Landroid/content/Context;)Z
    .locals 2

    .prologue
    .line 32
    invoke-static {p0}, Lcom/ta/utdid2/android/utils/f;->c(Landroid/content/Context;)Landroid/net/ConnectivityManager;

    move-result-object v0

    .line 33
    if-eqz v0, :cond_1

    .line 35
    :try_start_0
    invoke-virtual {v0}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v0

    .line 36
    if-eqz v0, :cond_0

    .line 37
    invoke-virtual {v0}, Landroid/net/NetworkInfo;->isConnected()Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result v0

    .line 45
    :goto_0
    return v0

    .line 39
    :catch_0
    move-exception v0

    .line 40
    const-string v1, "NetworkUtils"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 45
    :cond_0
    :goto_1
    const/4 v0, 0x0

    goto :goto_0

    .line 43
    :cond_1
    const-string v0, "NetworkUtils"

    const-string v1, "connManager is null!"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method

.method public static b(Landroid/content/Context;)Z
    .locals 6

    .prologue
    const/4 v0, 0x0

    .line 49
    invoke-static {p0}, Lcom/ta/utdid2/android/utils/f;->c(Landroid/content/Context;)Landroid/net/ConnectivityManager;

    move-result-object v1

    .line 51
    if-eqz v1, :cond_4

    .line 53
    :try_start_0
    invoke-virtual {v1}, Landroid/net/ConnectivityManager;->getActiveNetworkInfo()Landroid/net/NetworkInfo;

    move-result-object v1

    .line 54
    if-eqz v1, :cond_3

    .line 55
    invoke-virtual {v1}, Landroid/net/NetworkInfo;->getSubtype()I

    move-result v2

    .line 56
    sget-boolean v3, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v3, :cond_0

    const-string v3, "NetworkUtils"

    new-instance v4, Ljava/lang/StringBuilder;

    const-string v5, "subType:"

    invoke-direct {v4, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ": name:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v1}, Landroid/net/NetworkInfo;->getSubtypeName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v3, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 57
    :cond_0
    sget-object v3, Lcom/ta/utdid2/android/utils/f;->e:[I

    array-length v4, v3

    move v1, v0

    :goto_0
    if-lt v1, v4, :cond_1

    .line 71
    :goto_1
    return v0

    .line 57
    :cond_1
    aget v5, v3, v1

    .line 58
    if-ne v5, v2, :cond_2

    .line 59
    const/4 v0, 0x1

    goto :goto_1

    .line 57
    :cond_2
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 63
    :cond_3
    const-string v1, "NetworkUtils"

    const-string v2, "networkInfo is null!"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 65
    :catch_0
    move-exception v1

    .line 66
    const-string v2, "NetworkUtils"

    invoke-virtual {v1}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v2, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1

    .line 69
    :cond_4
    const-string v1, "NetworkUtils"

    const-string v2, "connManager is null!"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_1
.end method

.method private static c(Landroid/content/Context;)Landroid/net/ConnectivityManager;
    .locals 2

    .prologue
    .line 76
    if-nez p0, :cond_0

    .line 77
    const-string v0, "NetworkUtils"

    const-string v1, "context is null!"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 78
    const/4 v0, 0x0

    .line 85
    :goto_0
    return-object v0

    .line 80
    :cond_0
    sget-object v0, Lcom/ta/utdid2/android/utils/f;->d:Landroid/net/ConnectivityManager;

    if-nez v0, :cond_1

    .line 82
    const-string v0, "connectivity"

    invoke-virtual {p0, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    .line 81
    check-cast v0, Landroid/net/ConnectivityManager;

    sput-object v0, Lcom/ta/utdid2/android/utils/f;->d:Landroid/net/ConnectivityManager;

    .line 85
    :cond_1
    sget-object v0, Lcom/ta/utdid2/android/utils/f;->d:Landroid/net/ConnectivityManager;

    goto :goto_0
.end method

.method private static d(Landroid/content/Context;)[Ljava/lang/String;
    .locals 4

    .prologue
    const/4 v3, 0x1

    const/4 v2, 0x0

    .line 89
    const/4 v0, 0x2

    new-array v1, v0, [Ljava/lang/String;

    const-string v0, "Unknown"

    aput-object v0, v1, v2

    const-string v0, "Unknown"

    aput-object v0, v1, v3

    .line 92
    :try_start_0
    invoke-virtual {p0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    .line 94
    const-string v2, "android.permission.ACCESS_NETWORK_STATE"

    .line 95
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    .line 93
    invoke-virtual {v0, v2, v3}, Landroid/content/pm/PackageManager;->checkPermission(Ljava/lang/String;Ljava/lang/String;)I

    move-result v0

    if-eqz v0, :cond_0

    .line 96
    const/4 v0, 0x0

    const-string v2, "Unknown"

    aput-object v2, v1, v0

    move-object v0, v1

    .line 123
    :goto_0
    return-object v0

    .line 100
    :cond_0
    const-string v0, "connectivity"

    invoke-virtual {p0, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    .line 99
    check-cast v0, Landroid/net/ConnectivityManager;

    .line 101
    if-nez v0, :cond_1

    .line 102
    const/4 v0, 0x0

    const-string v2, "Unknown"

    aput-object v2, v1, v0

    move-object v0, v1

    .line 103
    goto :goto_0

    .line 106
    :cond_1
    const/4 v2, 0x1

    invoke-virtual {v0, v2}, Landroid/net/ConnectivityManager;->getNetworkInfo(I)Landroid/net/NetworkInfo;

    move-result-object v2

    .line 107
    if-eqz v2, :cond_2

    .line 108
    invoke-virtual {v2}, Landroid/net/NetworkInfo;->getState()Landroid/net/NetworkInfo$State;

    move-result-object v2

    sget-object v3, Landroid/net/NetworkInfo$State;->CONNECTED:Landroid/net/NetworkInfo$State;

    if-ne v2, v3, :cond_2

    .line 109
    const/4 v0, 0x0

    const-string v2, "Wi-Fi"

    aput-object v2, v1, v0

    move-object v0, v1

    .line 110
    goto :goto_0

    .line 113
    :cond_2
    const/4 v2, 0x0

    invoke-virtual {v0, v2}, Landroid/net/ConnectivityManager;->getNetworkInfo(I)Landroid/net/NetworkInfo;

    move-result-object v0

    .line 114
    if-eqz v0, :cond_3

    .line 115
    invoke-virtual {v0}, Landroid/net/NetworkInfo;->getState()Landroid/net/NetworkInfo$State;

    move-result-object v2

    sget-object v3, Landroid/net/NetworkInfo$State;->CONNECTED:Landroid/net/NetworkInfo$State;

    if-ne v2, v3, :cond_3

    .line 116
    const/4 v2, 0x0

    const-string v3, "2G/3G"

    aput-object v3, v1, v2

    .line 117
    const/4 v2, 0x1

    invoke-virtual {v0}, Landroid/net/NetworkInfo;->getSubtypeName()Ljava/lang/String;

    move-result-object v0

    aput-object v0, v1, v2
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-object v0, v1

    .line 118
    goto :goto_0

    :catch_0
    move-exception v0

    :cond_3
    move-object v0, v1

    .line 123
    goto :goto_0
.end method

.method private static e(Landroid/content/Context;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 127
    if-eqz p0, :cond_2

    .line 129
    const-string v0, "wifi"

    invoke-virtual {p0, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    .line 128
    check-cast v0, Landroid/net/wifi/WifiManager;

    .line 130
    invoke-virtual {v0}, Landroid/net/wifi/WifiManager;->getConnectionInfo()Landroid/net/wifi/WifiInfo;

    move-result-object v0

    .line 131
    if-eqz v0, :cond_1

    .line 132
    invoke-virtual {v0}, Landroid/net/wifi/WifiInfo;->getMacAddress()Ljava/lang/String;

    move-result-object v0

    .line 133
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 134
    const-string v0, "00-00-00-00-00-00"

    .line 141
    :cond_0
    :goto_0
    return-object v0

    .line 138
    :cond_1
    const-string v0, "00-00-00-00-00-00"

    goto :goto_0

    .line 141
    :cond_2
    const-string v0, "00-00-00-00-00-00"

    goto :goto_0
.end method

.method private static f(Landroid/content/Context;)Ljava/lang/String;
    .locals 4

    .prologue
    const/4 v1, 0x0

    .line 150
    if-eqz p0, :cond_1

    .line 153
    :try_start_0
    const-string v0, "wifi"

    invoke-virtual {p0, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    .line 152
    check-cast v0, Landroid/net/wifi/WifiManager;

    .line 154
    invoke-virtual {v0}, Landroid/net/wifi/WifiManager;->getConnectionInfo()Landroid/net/wifi/WifiInfo;

    move-result-object v0

    .line 155
    if-eqz v0, :cond_0

    .line 156
    invoke-virtual {v0}, Landroid/net/wifi/WifiInfo;->getIpAddress()I

    move-result v0

    .line 1145
    new-instance v2, Ljava/lang/StringBuilder;

    and-int/lit16 v3, v0, 0xff

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    const-string v3, "."

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    shr-int/lit8 v3, v0, 0x8

    and-int/lit16 v3, v3, 0xff

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "."

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    shr-int/lit8 v3, v0, 0x10

    and-int/lit16 v3, v3, 0xff

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v2

    .line 1146
    const-string v3, "."

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    shr-int/lit8 v0, v0, 0x18

    and-int/lit16 v0, v0, 0xff

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 1145
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 164
    :goto_0
    return-object v0

    :cond_0
    move-object v0, v1

    .line 158
    goto :goto_0

    :catch_0
    move-exception v0

    :cond_1
    move-object v0, v1

    .line 164
    goto :goto_0
.end method

.method private static g(Landroid/content/Context;)Z
    .locals 3

    .prologue
    const/4 v0, 0x0

    .line 168
    if-eqz p0, :cond_0

    .line 170
    :try_start_0
    invoke-static {p0}, Lcom/ta/utdid2/android/utils/f;->d(Landroid/content/Context;)[Ljava/lang/String;

    move-result-object v1

    const/4 v2, 0x0

    aget-object v1, v1, v2

    .line 171
    const-string v2, "Wi-Fi"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result v1

    if-eqz v1, :cond_0

    .line 172
    const/4 v0, 0x1

    .line 178
    :cond_0
    :goto_0
    return v0

    :catch_0
    move-exception v1

    goto :goto_0
.end method
