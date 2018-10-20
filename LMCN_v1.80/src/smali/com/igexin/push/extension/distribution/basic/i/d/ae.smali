.class Lcom/igexin/push/extension/distribution/basic/i/d/ae;
.super Ljava/lang/Object;


# static fields
.field private static final a:[Ljava/lang/String;


# instance fields
.field private b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

.field private c:Ljava/lang/String;

.field private d:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/d/g;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method static constructor <clinit>()V
    .locals 3

    const/4 v0, 0x5

    new-array v0, v0, [Ljava/lang/String;

    const/4 v1, 0x0

    const-string v2, ","

    aput-object v2, v0, v1

    const/4 v1, 0x1

    const-string v2, ">"

    aput-object v2, v0, v1

    const/4 v1, 0x2

    const-string v2, "+"

    aput-object v2, v0, v1

    const/4 v1, 0x3

    const-string v2, "~"

    aput-object v2, v0, v1

    const/4 v1, 0x4

    const-string v2, " "

    aput-object v2, v0, v1

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a:[Ljava/lang/String;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->c:Ljava/lang/String;

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-direct {v0, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    return-void
.end method

.method public static a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/g;
    .locals 1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;

    invoke-direct {v0, p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a()Lcom/igexin/push/extension/distribution/basic/i/d/g;

    move-result-object v0

    return-object v0
.end method

.method private a(C)V
    .locals 10

    const/16 v8, 0x2c

    const/4 v7, 0x2

    const/4 v3, 0x1

    const/4 v4, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->e()Z

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/g;

    move-result-object v6

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-ne v0, v3, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-interface {v0, v4}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/d/g;

    instance-of v1, v0, Lcom/igexin/push/extension/distribution/basic/i/d/e;

    if-eqz v1, :cond_8

    if-eq p1, v8, :cond_8

    move-object v1, v0

    check-cast v1, Lcom/igexin/push/extension/distribution/basic/i/d/e;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/d/e;->a()Lcom/igexin/push/extension/distribution/basic/i/d/g;

    move-result-object v1

    move v2, v3

    move-object v9, v1

    move-object v1, v0

    move-object v0, v9

    :goto_0
    iget-object v5, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-interface {v5}, Ljava/util/List;->clear()V

    const/16 v5, 0x3e

    if-ne p1, v5, :cond_1

    new-instance v5, Lcom/igexin/push/extension/distribution/basic/i/d/d;

    new-array v7, v7, [Lcom/igexin/push/extension/distribution/basic/i/d/g;

    aput-object v6, v7, v4

    new-instance v4, Lcom/igexin/push/extension/distribution/basic/i/d/aj;

    invoke-direct {v4, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/aj;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    aput-object v4, v7, v3

    invoke-direct {v5, v7}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>([Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    move-object v3, v5

    :goto_1
    if-eqz v2, :cond_7

    move-object v0, v1

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/d/e;

    invoke-virtual {v0, v3}, Lcom/igexin/push/extension/distribution/basic/i/d/e;->a(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    :goto_2
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void

    :cond_0
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/d;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>(Ljava/util/Collection;)V

    move v2, v4

    move-object v1, v0

    goto :goto_0

    :cond_1
    const/16 v5, 0x20

    if-ne p1, v5, :cond_2

    new-instance v5, Lcom/igexin/push/extension/distribution/basic/i/d/d;

    new-array v7, v7, [Lcom/igexin/push/extension/distribution/basic/i/d/g;

    aput-object v6, v7, v4

    new-instance v4, Lcom/igexin/push/extension/distribution/basic/i/d/am;

    invoke-direct {v4, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/am;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    aput-object v4, v7, v3

    invoke-direct {v5, v7}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>([Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    move-object v3, v5

    goto :goto_1

    :cond_2
    const/16 v5, 0x2b

    if-ne p1, v5, :cond_3

    new-instance v5, Lcom/igexin/push/extension/distribution/basic/i/d/d;

    new-array v7, v7, [Lcom/igexin/push/extension/distribution/basic/i/d/g;

    aput-object v6, v7, v4

    new-instance v4, Lcom/igexin/push/extension/distribution/basic/i/d/ak;

    invoke-direct {v4, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ak;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    aput-object v4, v7, v3

    invoke-direct {v5, v7}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>([Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    move-object v3, v5

    goto :goto_1

    :cond_3
    const/16 v5, 0x7e

    if-ne p1, v5, :cond_4

    new-instance v5, Lcom/igexin/push/extension/distribution/basic/i/d/d;

    new-array v7, v7, [Lcom/igexin/push/extension/distribution/basic/i/d/g;

    aput-object v6, v7, v4

    new-instance v4, Lcom/igexin/push/extension/distribution/basic/i/d/an;

    invoke-direct {v4, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/an;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    aput-object v4, v7, v3

    invoke-direct {v5, v7}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>([Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    move-object v3, v5

    goto :goto_1

    :cond_4
    if-ne p1, v8, :cond_6

    instance-of v3, v0, Lcom/igexin/push/extension/distribution/basic/i/d/e;

    if-eqz v3, :cond_5

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/d/e;

    invoke-virtual {v0, v6}, Lcom/igexin/push/extension/distribution/basic/i/d/e;->b(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    :goto_3
    move-object v3, v0

    goto :goto_1

    :cond_5
    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/e;

    invoke-direct {v3}, Lcom/igexin/push/extension/distribution/basic/i/d/e;-><init>()V

    invoke-virtual {v3, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/e;->b(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    invoke-virtual {v3, v6}, Lcom/igexin/push/extension/distribution/basic/i/d/e;->b(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    move-object v0, v3

    goto :goto_3

    :cond_6
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/ag;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unknown combinator: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    new-array v2, v4, [Ljava/lang/Object;

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d/ag;-><init>(Ljava/lang/String;[Ljava/lang/Object;)V

    throw v0

    :cond_7
    move-object v1, v3

    goto/16 :goto_2

    :cond_8
    move v2, v4

    move-object v1, v0

    goto/16 :goto_0
.end method

.method private a(Z)V
    .locals 3

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    if-eqz p1, :cond_0

    const-string v0, ":containsOwn"

    :goto_0
    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v1, 0x28

    const/16 v2, 0x29

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->f(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const-string v1, ":contains(text) query must not be empty"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;Ljava/lang/String;)V

    if-eqz p1, :cond_1

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/s;

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/s;-><init>(Ljava/lang/String;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :goto_1
    return-void

    :cond_0
    const-string v0, ":contains"

    goto :goto_0

    :cond_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/t;

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/t;-><init>(Ljava/lang/String;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_1
.end method

.method private b()Ljava/lang/String;
    .locals 5

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    :goto_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v1

    if-nez v1, :cond_2

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v2, "("

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_0

    const-string v1, "("

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v3, 0x28

    const/16 v4, 0x29

    invoke-virtual {v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ")"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0

    :cond_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v2, "["

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    const-string v1, "["

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v3, 0x5b

    const/16 v4, 0x5d

    invoke-virtual {v2, v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "]"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_0

    :cond_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a:[Ljava/lang/String;

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a([Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3

    :cond_2
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0

    :cond_3
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->d()C

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    goto :goto_0
.end method

.method private b(Z)V
    .locals 3

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    if-eqz p1, :cond_0

    const-string v0, ":matchesOwn"

    :goto_0
    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v1, 0x28

    const/16 v2, 0x29

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v0

    const-string v1, ":matches(regex) query must not be empty"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;Ljava/lang/String;)V

    if-eqz p1, :cond_1

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/aa;

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/aa;-><init>(Ljava/util/regex/Pattern;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :goto_1
    return-void

    :cond_0
    const-string v0, ":matches"

    goto :goto_0

    :cond_1
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/z;

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/z;-><init>(Ljava/util/regex/Pattern;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_1
.end method

.method private c()V
    .locals 6

    const/4 v5, 0x1

    const/4 v4, 0x0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, "#"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d()V

    :goto_0
    return-void

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, "."

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->e()V

    goto :goto_0

    :cond_1
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c()Z

    move-result v0

    if-eqz v0, :cond_2

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->f()V

    goto :goto_0

    :cond_2
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, "["

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->g()V

    goto :goto_0

    :cond_3
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, "*"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->h()V

    goto :goto_0

    :cond_4
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":lt("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_5

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->i()V

    goto :goto_0

    :cond_5
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":gt("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_6

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->j()V

    goto :goto_0

    :cond_6
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":eq("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_7

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->k()V

    goto :goto_0

    :cond_7
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":has("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_8

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->m()V

    goto :goto_0

    :cond_8
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":contains("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_9

    invoke-direct {p0, v4}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(Z)V

    goto :goto_0

    :cond_9
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":containsOwn("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_a

    invoke-direct {p0, v5}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(Z)V

    goto/16 :goto_0

    :cond_a
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":matches("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_b

    invoke-direct {p0, v4}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b(Z)V

    goto/16 :goto_0

    :cond_b
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":matchesOwn("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_c

    invoke-direct {p0, v5}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b(Z)V

    goto/16 :goto_0

    :cond_c
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":not("

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_d

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->n()V

    goto/16 :goto_0

    :cond_d
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/ag;

    const-string v1, "Could not parse query \'%s\': unexpected token at \'%s\'"

    const/4 v2, 0x2

    new-array v2, v2, [Ljava/lang/Object;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->c:Ljava/lang/String;

    aput-object v3, v2, v4

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v3

    aput-object v3, v2, v5

    invoke-direct {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d/ag;-><init>(Ljava/lang/String;[Ljava/lang/Object;)V

    throw v0
.end method

.method private d()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->g()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/u;

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/u;-><init>(Ljava/lang/String;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private e()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->g()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/r;

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/r;-><init>(Ljava/lang/String;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private f()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->f()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    const-string v1, "|"

    invoke-virtual {v0, v1}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_0

    const-string v1, "|"

    const-string v2, ":"

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    :cond_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/ab;

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->toLowerCase()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ab;-><init>(Ljava/lang/String;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private g()V
    .locals 7

    const/4 v4, 0x2

    const/4 v6, 0x0

    const/4 v5, 0x1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v2, 0x5b

    const/16 v3, 0x5d

    invoke-virtual {v1, v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;-><init>(Ljava/lang/String;)V

    const/4 v1, 0x6

    new-array v1, v1, [Ljava/lang/String;

    const-string v2, "="

    aput-object v2, v1, v6

    const-string v2, "!="

    aput-object v2, v1, v5

    const-string v2, "^="

    aput-object v2, v1, v4

    const/4 v2, 0x3

    const-string v3, "$="

    aput-object v3, v1, v2

    const/4 v2, 0x4

    const-string v3, "*="

    aput-object v3, v1, v2

    const/4 v2, 0x5

    const-string v3, "~="

    aput-object v3, v1, v2

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b([Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;)V

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->e()Z

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v2

    if-eqz v2, :cond_1

    const-string v0, "^"

    invoke-virtual {v1, v0}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/k;

    invoke-virtual {v1, v5}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v2, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/k;-><init>(Ljava/lang/String;)V

    invoke-interface {v0, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :goto_0
    return-void

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/i;

    invoke-direct {v2, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/i;-><init>(Ljava/lang/String;)V

    invoke-interface {v0, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_1
    const-string v2, "="

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_2

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/l;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/l;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_2
    const-string v2, "!="

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_3

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/p;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/p;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_3
    const-string v2, "^="

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_4

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/q;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/q;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_4
    const-string v2, "$="

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_5

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/n;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/n;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_5
    const-string v2, "*="

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_6

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/m;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/m;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_6
    const-string v2, "~="

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_7

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/i/d/o;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    invoke-direct {v3, v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/o;-><init>(Ljava/lang/String;Ljava/util/regex/Pattern;)V

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto/16 :goto_0

    :cond_7
    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/ag;

    const-string v2, "Could not parse attribute query \'%s\': unexpected token at \'%s\'"

    new-array v3, v4, [Ljava/lang/Object;

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->c:Ljava/lang/String;

    aput-object v4, v3, v6

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->h()Ljava/lang/String;

    move-result-object v0

    aput-object v0, v3, v5

    invoke-direct {v1, v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/d/ag;-><init>(Ljava/lang/String;[Ljava/lang/Object;)V

    throw v1
.end method

.method private h()V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/h;

    invoke-direct {v1}, Lcom/igexin/push/extension/distribution/basic/i/d/h;-><init>()V

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private i()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/y;

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->l()I

    move-result v2

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d/y;-><init>(I)V

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private j()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/x;

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->l()I

    move-result v2

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d/x;-><init>(I)V

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private k()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/v;

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->l()I

    move-result v2

    invoke-direct {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/d/v;-><init>(I)V

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private l()I
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ")"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->e(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->b(Ljava/lang/String;)Z

    move-result v1

    const-string v2, "Index must be numeric"

    invoke-static {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(ZLjava/lang/String;)V

    invoke-static {v0}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v0

    return v0
.end method

.method private m()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":has"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v1, 0x28

    const/16 v2, 0x29

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v0

    const-string v1, ":has(el) subselect must not be empty"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/ai;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/g;

    move-result-object v0

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ai;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method

.method private n()V
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const-string v1, ":not"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->c(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    const/16 v1, 0x28

    const/16 v2, 0x29

    invoke-virtual {v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a(CC)Ljava/lang/String;

    move-result-object v0

    const-string v1, ":not(selector) subselect must not be empty"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;Ljava/lang/String;)V

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/d/al;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/g;

    move-result-object v0

    invoke-direct {v2, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/al;-><init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V

    invoke-interface {v1, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-void
.end method


# virtual methods
.method a()Lcom/igexin/push/extension/distribution/basic/i/d/g;
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->e()Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a:[Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a([Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/i/d/ao;

    invoke-direct {v1}, Lcom/igexin/push/extension/distribution/basic/i/d/ao;-><init>()V

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->d()C

    move-result v0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(C)V

    :goto_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a()Z

    move-result v0

    if-nez v0, :cond_3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->e()Z

    move-result v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a:[Ljava/lang/String;

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->a([Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ap;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ap;->d()C

    move-result v0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(C)V

    goto :goto_0

    :cond_0
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->c()V

    goto :goto_0

    :cond_1
    if-eqz v0, :cond_2

    const/16 v0, 0x20

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->a(C)V

    goto :goto_0

    :cond_2
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->c()V

    goto :goto_0

    :cond_3
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_4

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    const/4 v1, 0x0

    invoke-interface {v0, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/d/g;

    :goto_1
    return-object v0

    :cond_4
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/d/d;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/ae;->d:Ljava/util/List;

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>(Ljava/util/Collection;)V

    goto :goto_1
.end method
