.class public final Lcom/ta/utdid2/android/utils/d;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static a:Z = false

.field private static final b:Ljava/lang/String; = "alidebug"

.field private static c:Ljava/lang/Class;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/Class",
            "<*>;"
        }
    .end annotation
.end field

.field private static d:Ljava/lang/reflect/Method;

.field private static e:Ljava/lang/reflect/Method;


# direct methods
.method static constructor <clinit>()V
    .locals 3

    .prologue
    const/4 v0, 0x1

    const/4 v2, 0x0

    .line 42
    const-string v1, "alidebug"

    invoke-static {v1}, Lcom/ta/utdid2/android/utils/d;->b(Ljava/lang/String;)I

    move-result v1

    if-ne v1, v0, :cond_0

    :goto_0
    sput-boolean v0, Lcom/ta/utdid2/android/utils/d;->a:Z

    .line 44
    sput-object v2, Lcom/ta/utdid2/android/utils/d;->c:Ljava/lang/Class;

    .line 45
    sput-object v2, Lcom/ta/utdid2/android/utils/d;->d:Ljava/lang/reflect/Method;

    .line 46
    sput-object v2, Lcom/ta/utdid2/android/utils/d;->e:Ljava/lang/reflect/Method;

    return-void

    .line 42
    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static a(Ljava/lang/String;)Ljava/lang/String;
    .locals 5

    .prologue
    .line 16
    invoke-static {}, Lcom/ta/utdid2/android/utils/d;->a()V

    .line 18
    const/4 v1, 0x0

    .line 21
    :try_start_0
    sget-object v0, Lcom/ta/utdid2/android/utils/d;->d:Ljava/lang/reflect/Method;

    sget-object v2, Lcom/ta/utdid2/android/utils/d;->c:Ljava/lang/Class;

    const/4 v3, 0x1

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object p0, v3, v4

    invoke-virtual {v0, v2, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 26
    :goto_0
    return-object v0

    .line 23
    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    move-object v0, v1

    goto :goto_0
.end method

.method private static a()V
    .locals 5

    .prologue
    .line 49
    :try_start_0
    sget-object v0, Lcom/ta/utdid2/android/utils/d;->c:Ljava/lang/Class;

    if-nez v0, :cond_0

    .line 50
    const-string v0, "android.os.SystemProperties"

    invoke-static {v0}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object v0

    .line 52
    sput-object v0, Lcom/ta/utdid2/android/utils/d;->c:Ljava/lang/Class;

    const-string v1, "get"

    const/4 v2, 0x1

    new-array v2, v2, [Ljava/lang/Class;

    const/4 v3, 0x0

    const-class v4, Ljava/lang/String;

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Ljava/lang/Class;->getDeclaredMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    sput-object v0, Lcom/ta/utdid2/android/utils/d;->d:Ljava/lang/reflect/Method;

    .line 53
    sget-object v0, Lcom/ta/utdid2/android/utils/d;->c:Ljava/lang/Class;

    const-string v1, "getInt"

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/Class;

    const/4 v3, 0x0

    const-class v4, Ljava/lang/String;

    aput-object v4, v2, v3

    const/4 v3, 0x1

    sget-object v4, Ljava/lang/Integer;->TYPE:Ljava/lang/Class;

    aput-object v4, v2, v3

    invoke-virtual {v0, v1, v2}, Ljava/lang/Class;->getDeclaredMethod(Ljava/lang/String;[Ljava/lang/Class;)Ljava/lang/reflect/Method;

    move-result-object v0

    sput-object v0, Lcom/ta/utdid2/android/utils/d;->e:Ljava/lang/reflect/Method;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 58
    :cond_0
    :goto_0
    return-void

    .line 56
    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method private static b(Ljava/lang/String;)I
    .locals 6

    .prologue
    const/4 v1, 0x0

    .line 30
    invoke-static {}, Lcom/ta/utdid2/android/utils/d;->a()V

    .line 34
    :try_start_0
    sget-object v0, Lcom/ta/utdid2/android/utils/d;->e:Ljava/lang/reflect/Method;

    sget-object v2, Lcom/ta/utdid2/android/utils/d;->c:Ljava/lang/Class;

    const/4 v3, 0x2

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    aput-object p0, v3, v4

    const/4 v4, 0x1

    const/4 v5, 0x0

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    aput-object v5, v3, v4

    invoke-virtual {v0, v2, v3}, Ljava/lang/reflect/Method;->invoke(Ljava/lang/Object;[Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Integer;

    .line 35
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result v0

    .line 39
    :goto_0
    return v0

    .line 37
    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    move v0, v1

    goto :goto_0
.end method
