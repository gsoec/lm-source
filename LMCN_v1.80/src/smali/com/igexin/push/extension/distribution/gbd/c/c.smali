.class public Lcom/igexin/push/extension/distribution/gbd/c/c;
.super Ljava/lang/Object;


# static fields
.field public static A:Ljava/lang/String;

.field public static B:J

.field public static C:Ljava/lang/String;

.field public static D:Ljava/lang/String;

.field public static E:J

.field public static a:Landroid/content/Context;

.field public static b:Lcom/igexin/push/extension/distribution/gbd/e/a;

.field public static c:Lcom/igexin/push/extension/distribution/gbd/d/a;

.field public static d:Landroid/net/wifi/WifiManager;

.field public static e:Ljava/net/ServerSocket;

.field public static f:Z

.field public static g:J

.field public static h:J

.field public static i:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/lang/Long;",
            ">;"
        }
    .end annotation
.end field

.field public static j:J

.field public static k:J

.field public static l:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Lcom/igexin/push/extension/distribution/gbd/b/a;",
            ">;"
        }
    .end annotation
.end field

.field public static m:I

.field public static n:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field public static o:J

.field public static p:Ljava/lang/String;

.field public static q:Ljava/lang/String;

.field public static r:Ljava/lang/String;

.field public static s:J

.field public static t:J

.field public static u:J

.field public static v:Ljava/lang/String;

.field public static w:J

.field public static x:J

.field public static y:J

.field public static z:I


# direct methods
.method static constructor <clinit>()V
    .locals 4

    const-wide/16 v2, 0x0

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->g:J

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->i:Ljava/util/List;

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->j:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->k:J

    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->l:Ljava/util/Map;

    const/4 v0, 0x0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->m:I

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->o:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->s:J

    const-string v0, ""

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->A:Ljava/lang/String;

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->E:J

    return-void
.end method
