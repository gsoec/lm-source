.class public final enum Lcom/igexin/push/extension/distribution/basic/i/b/k;
.super Ljava/lang/Enum;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum",
        "<",
        "Lcom/igexin/push/extension/distribution/basic/i/b/k;",
        ">;"
    }
.end annotation


# static fields
.field public static final enum a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

.field public static final enum b:Lcom/igexin/push/extension/distribution/basic/i/b/k;

.field public static final enum c:Lcom/igexin/push/extension/distribution/basic/i/b/k;

.field private static final synthetic e:[Lcom/igexin/push/extension/distribution/basic/i/b/k;


# instance fields
.field private d:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 6

    const/4 v5, 0x2

    const/4 v4, 0x1

    const/4 v3, 0x0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;

    const-string v1, "xhtml"

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->a()Ljava/util/Map;

    move-result-object v2

    invoke-direct {v0, v1, v3, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/k;-><init>(Ljava/lang/String;ILjava/util/Map;)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;

    const-string v1, "base"

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->b()Ljava/util/Map;

    move-result-object v2

    invoke-direct {v0, v1, v4, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/k;-><init>(Ljava/lang/String;ILjava/util/Map;)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->b:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;

    const-string v1, "extended"

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/b/j;->c()Ljava/util/Map;

    move-result-object v2

    invoke-direct {v0, v1, v5, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/k;-><init>(Ljava/lang/String;ILjava/util/Map;)V

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->c:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    const/4 v0, 0x3

    new-array v0, v0, [Lcom/igexin/push/extension/distribution/basic/i/b/k;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/k;->a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    aput-object v1, v0, v3

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/k;->b:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    aput-object v1, v0, v4

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/b/k;->c:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    aput-object v1, v0, v5

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->e:[Lcom/igexin/push/extension/distribution/basic/i/b/k;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;ILjava/util/Map;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    iput-object p3, p0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->d:Ljava/util/Map;

    return-void
.end method

.method public static a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/k;
    .locals 1

    const-class v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;

    return-object v0
.end method


# virtual methods
.method public a()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/Character;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->d:Ljava/util/Map;

    return-object v0
.end method
