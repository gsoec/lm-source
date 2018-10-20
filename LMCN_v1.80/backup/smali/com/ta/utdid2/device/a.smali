.class public final Lcom/ta/utdid2/device/a;
.super Ljava/lang/Object;
.source "SourceFile"


# instance fields
.field a:Ljava/lang/String;

.field b:Ljava/lang/String;

.field c:Ljava/lang/String;

.field d:Ljava/lang/String;

.field e:J

.field f:J


# direct methods
.method public constructor <init>()V
    .locals 4

    .prologue
    const-wide/16 v2, 0x0

    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 11
    const-string v0, ""

    iput-object v0, p0, Lcom/ta/utdid2/device/a;->a:Ljava/lang/String;

    .line 12
    const-string v0, ""

    iput-object v0, p0, Lcom/ta/utdid2/device/a;->b:Ljava/lang/String;

    .line 13
    const-string v0, ""

    iput-object v0, p0, Lcom/ta/utdid2/device/a;->c:Ljava/lang/String;

    .line 14
    const-string v0, ""

    iput-object v0, p0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    .line 15
    iput-wide v2, p0, Lcom/ta/utdid2/device/a;->e:J

    .line 16
    iput-wide v2, p0, Lcom/ta/utdid2/device/a;->f:J

    .line 9
    return-void
.end method

.method private a()J
    .locals 2

    .prologue
    .line 19
    iget-wide v0, p0, Lcom/ta/utdid2/device/a;->f:J

    return-wide v0
.end method

.method private a(J)V
    .locals 1

    .prologue
    .line 23
    iput-wide p1, p0, Lcom/ta/utdid2/device/a;->f:J

    .line 24
    return-void
.end method

.method private a(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 39
    iput-object p1, p0, Lcom/ta/utdid2/device/a;->a:Ljava/lang/String;

    .line 40
    return-void
.end method

.method private b()J
    .locals 2

    .prologue
    .line 27
    iget-wide v0, p0, Lcom/ta/utdid2/device/a;->e:J

    return-wide v0
.end method

.method private b(J)V
    .locals 1

    .prologue
    .line 31
    iput-wide p1, p0, Lcom/ta/utdid2/device/a;->e:J

    .line 32
    return-void
.end method

.method private b(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 47
    iput-object p1, p0, Lcom/ta/utdid2/device/a;->b:Ljava/lang/String;

    .line 48
    return-void
.end method

.method private c()Ljava/lang/String;
    .locals 1

    .prologue
    .line 35
    iget-object v0, p0, Lcom/ta/utdid2/device/a;->a:Ljava/lang/String;

    return-object v0
.end method

.method private c(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 55
    iput-object p1, p0, Lcom/ta/utdid2/device/a;->c:Ljava/lang/String;

    .line 56
    return-void
.end method

.method private d()Ljava/lang/String;
    .locals 1

    .prologue
    .line 43
    iget-object v0, p0, Lcom/ta/utdid2/device/a;->b:Ljava/lang/String;

    return-object v0
.end method

.method private d(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 63
    iput-object p1, p0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    .line 64
    return-void
.end method

.method private e()Ljava/lang/String;
    .locals 1

    .prologue
    .line 51
    iget-object v0, p0, Lcom/ta/utdid2/device/a;->c:Ljava/lang/String;

    return-object v0
.end method

.method private f()Ljava/lang/String;
    .locals 1

    .prologue
    .line 59
    iget-object v0, p0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    return-object v0
.end method
