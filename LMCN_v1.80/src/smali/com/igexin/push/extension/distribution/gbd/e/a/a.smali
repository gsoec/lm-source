.class public Lcom/igexin/push/extension/distribution/gbd/e/a/a;
.super Ljava/lang/Object;


# static fields
.field public static a:Lcom/igexin/push/extension/distribution/gbd/e/a/a;


# instance fields
.field private A:Z

.field private B:Z

.field private C:I

.field private D:I

.field private E:Z

.field private F:Ljava/lang/String;

.field private G:I

.field private H:Ljava/lang/String;

.field private I:Z

.field private J:Ljava/lang/String;

.field private K:Z

.field private L:Z

.field private M:Z

.field private N:J

.field private O:I

.field private P:I

.field private Q:Ljava/lang/String;

.field private R:Ljava/lang/String;

.field private S:Ljava/lang/String;

.field private T:J

.field private U:J

.field private V:Z

.field private W:Z

.field private X:I

.field private Y:J

.field private Z:I

.field private aa:Z

.field private ab:J

.field private ac:Ljava/lang/String;

.field private ad:I

.field private ae:J

.field private af:Z

.field private ag:Ljava/lang/String;

.field private ah:Ljava/lang/String;

.field private ai:Ljava/lang/String;

.field private aj:Z

.field private ak:Z

.field private al:Z

.field private am:Ljava/lang/String;

.field private an:J

.field private b:Z

.field private c:Ljava/lang/String;

.field private d:Ljava/lang/String;

.field private e:Z

.field private f:J

.field private g:J

.field private h:I

.field private i:I

.field private j:I

.field private k:I

.field private l:J

.field private m:I

.field private n:I

.field private o:Z

.field private p:Ljava/lang/String;

.field private q:I

.field private r:Ljava/lang/String;

.field private s:Ljava/lang/String;

.field private t:J

.field private u:Z

.field private v:J

.field private w:J

.field private x:I

.field private y:I

.field private z:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 1

    const/4 v0, 0x1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aj:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ak:Z

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->al:Z

    const-string v0, "none"

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->am:Ljava/lang/String;

    return-void
.end method

.method public static a()Lcom/igexin/push/extension/distribution/gbd/e/a/a;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a:Lcom/igexin/push/extension/distribution/gbd/e/a/a;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a:Lcom/igexin/push/extension/distribution/gbd/e/a/a;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a:Lcom/igexin/push/extension/distribution/gbd/e/a/a;

    return-object v0
.end method

.method private a(ILjava/lang/String;)V
    .locals 4

    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    const-string v1, "key"

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Integer;)V

    const-string v1, "value"

    invoke-virtual {v0, v1, p2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->b:Lcom/igexin/push/extension/distribution/gbd/e/a;

    const-string v2, "config"

    const/4 v3, 0x0

    invoke-virtual {v1, v2, v3, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a;->a(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V

    return-void
.end method

.method private a(I[B)V
    .locals 4

    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    const-string v1, "key"

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Integer;)V

    const-string v1, "value"

    invoke-virtual {v0, v1, p2}, Landroid/content/ContentValues;->put(Ljava/lang/String;[B)V

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->b:Lcom/igexin/push/extension/distribution/gbd/e/a;

    const-string v2, "config"

    const/4 v3, 0x0

    invoke-virtual {v1, v2, v3, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a;->a(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V

    return-void
.end method

.method private c()V
    .locals 11

    const/16 v10, 0x32

    const/16 v9, 0x31

    const/16 v8, 0x30

    const/4 v2, 0x0

    const/4 v1, 0x1

    const-string v0, "GBD_ConfigDataManager"

    const-string v3, "saveAllData"

    invoke-static {v0, v3}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->b:Z

    iget-boolean v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->b:Z

    if-eq v0, v3, :cond_0

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->b:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->b:Z

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->b:Z

    invoke-static {v0}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v2, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->c:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->c:Ljava/lang/String;

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->c:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->c:Ljava/lang/String;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->c:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v0

    invoke-direct {p0, v1, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_1
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->d:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->d:Ljava/lang/String;

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->d:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->d:Ljava/lang/String;

    const/4 v0, 0x2

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->d:Ljava/lang/String;

    invoke-virtual {v3}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_2
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->e:Z

    iget-boolean v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->e:Z

    if-eq v0, v3, :cond_3

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->e:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->e:Z

    const/4 v0, 0x3

    sget-boolean v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->e:Z

    invoke-static {v3}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_3
    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    iget-wide v6, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->f:J

    cmp-long v0, v4, v6

    if-eqz v0, :cond_4

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->f:J

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    const/4 v0, 0x4

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->d()Lcom/igexin/push/extension/distribution/gbd/h/a/h;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/h/a/h;->e()V

    :cond_4
    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->g:J

    iget-wide v6, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->g:J

    cmp-long v0, v4, v6

    if-eqz v0, :cond_5

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->g:J

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->g:J

    const/4 v0, 0x5

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->g:J

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/h/a/l;->d()Lcom/igexin/push/extension/distribution/gbd/h/a/l;

    move-result-object v0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    invoke-virtual {v0, v4, v5}, Lcom/igexin/push/extension/distribution/gbd/h/a/l;->a(J)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/h/a/l;->d()Lcom/igexin/push/extension/distribution/gbd/h/a/l;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/h/a/l;->e()V

    :cond_5
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->h:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->h:I

    if-eq v0, v3, :cond_6

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->h:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->h:I

    const/4 v0, 0x6

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->h:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_6
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->i:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->i:I

    if-eq v0, v3, :cond_7

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->i:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->i:I

    const/4 v0, 0x7

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->i:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_7
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->j:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->j:I

    if-eq v0, v3, :cond_8

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->j:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->j:I

    const/16 v0, 0x8

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->j:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_8
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->k:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->k:I

    if-eq v0, v3, :cond_9

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->k:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->k:I

    const/16 v0, 0x9

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->k:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_9
    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->l:J

    iget-wide v6, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->l:J

    cmp-long v0, v4, v6

    if-eqz v0, :cond_a

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->l:J

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->l:J

    const/16 v0, 0xa

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->l:J

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_a
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->m:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->m:I

    if-eq v0, v3, :cond_b

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->m:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->m:I

    const/16 v0, 0xb

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->m:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_b
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->o:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->n:I

    if-eq v0, v3, :cond_c

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->n:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->o:I

    const/16 v0, 0xc

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->o:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_c
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->q:Z

    if-nez v0, :cond_46

    move v0, v1

    :goto_0
    iget-boolean v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->o:Z

    if-ne v0, v3, :cond_d

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->o:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->q:Z

    const/16 v0, 0xe

    sget-boolean v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->q:Z

    invoke-static {v3}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_d
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->r:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->p:Ljava/lang/String;

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_e

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->p:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->r:Ljava/lang/String;

    const/16 v0, 0xf

    sget-object v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->r:Ljava/lang/String;

    invoke-virtual {v3}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_e
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->t:I

    iget v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->q:I

    if-eq v0, v3, :cond_f

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->q:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->t:I

    const/16 v0, 0x10

    sget v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->t:I

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_f
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->v:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->s:Ljava/lang/String;

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_10

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->s:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->v:Ljava/lang/String;

    const/16 v0, 0x12

    sget-object v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->v:Ljava/lang/String;

    invoke-virtual {v3}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_10
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->v:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->r:Ljava/lang/String;

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_11

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->r:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->u:Ljava/lang/String;

    const/16 v0, 0x11

    sget-object v3, Lcom/igexin/push/extension/distribution/gbd/c/a;->u:Ljava/lang/String;

    invoke-virtual {v3}, Ljava/lang/String;->getBytes()[B

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_11
    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->w:J

    iget-wide v6, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->t:J

    cmp-long v0, v4, v6

    if-eqz v0, :cond_12

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->t:J

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->w:J

    const/16 v0, 0x13

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->w:J

    invoke-static {v4, v5}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v3

    invoke-direct {p0, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_12
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->p:Z

    if-nez v0, :cond_13

    move v2, v1

    :cond_13
    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->u:Z

    if-ne v2, v0, :cond_14

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->u:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->p:Z

    const/16 v0, 0x14

    sget-boolean v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->p:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_14
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->y:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->v:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_15

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->v:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->y:J

    const/16 v0, 0x15

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->y:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/h/a/c;->d()Lcom/igexin/push/extension/distribution/gbd/h/a/c;

    move-result-object v0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-virtual {v0, v2, v3}, Lcom/igexin/push/extension/distribution/gbd/h/a/c;->a(J)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/h/a/c;->d()Lcom/igexin/push/extension/distribution/gbd/h/a/c;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/gbd/h/a/c;->e()V

    :cond_15
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->n:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->w:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_16

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->w:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->n:J

    const/16 v0, 0x16

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->n:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_16
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->B:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->x:I

    if-eq v0, v2, :cond_17

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->x:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->B:I

    const/16 v0, 0x1b

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->x:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_17
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->C:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->y:I

    if-eq v0, v2, :cond_18

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->y:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->C:I

    const/16 v0, 0x1c

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->y:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_18
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->G:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->A:Z

    if-eq v0, v2, :cond_19

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->A:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->G:Z

    const/16 v0, 0x1e

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->A:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_19
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->D:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->z:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1a

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->z:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->D:Ljava/lang/String;

    const/16 v0, 0x1d

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->D:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_1a
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->K:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->B:Z

    if-eq v0, v2, :cond_1b

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->B:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->K:Z

    const/16 v0, 0x1f

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->B:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_1b
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->L:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->C:I

    if-eq v0, v2, :cond_1c

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->C:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->L:I

    const/16 v0, 0x20

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->C:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_1c
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->M:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->D:I

    if-eq v0, v2, :cond_1d

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->D:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->M:I

    const/16 v0, 0x21

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->D:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_1d
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->H:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->E:Z

    if-eq v0, v2, :cond_1e

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->E:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->H:Z

    const/16 v0, 0x22

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->E:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_1e
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->J:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->F:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->F:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->J:Ljava/lang/String;

    const/16 v0, 0x23

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->J:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_1f
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->I:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->G:I

    if-eq v0, v2, :cond_20

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->G:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->I:I

    const/16 v0, 0x24

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->G:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_20
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->s:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->H:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_21

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->H:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->s:Ljava/lang/String;

    const/16 v0, 0x26

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->s:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_21
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->N:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->I:Z

    if-eq v0, v2, :cond_22

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->I:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->N:Z

    const/16 v0, 0x27

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->I:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_22
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->E:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->J:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_23

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->J:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->E:Ljava/lang/String;

    const/16 v0, 0x29

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->E:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_23
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->O:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->K:Z

    if-eq v0, v2, :cond_24

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->K:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->O:Z

    const/16 v0, 0x2c

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->K:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_24
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->F:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->L:Z

    if-eq v0, v2, :cond_25

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->L:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->F:Z

    const/16 v0, 0x2e

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->L:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_25
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->P:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    if-eq v0, v2, :cond_26

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->P:Z

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    invoke-static {v0}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v8, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_26
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->N:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_27

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->N:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v9, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_27
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->O:I

    if-eq v0, v2, :cond_28

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->O:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    invoke-static {v0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v10, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_28
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->P:I

    if-eq v0, v2, :cond_29

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->P:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    const/16 v0, 0x34

    sget v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_29
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->P:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    if-eq v0, v2, :cond_2a

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->P:Z

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    invoke-static {v0}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v8, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_2a
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->N:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_2b

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->N:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v9, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_2b
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->O:I

    if-eq v0, v2, :cond_2c

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->O:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    invoke-static {v0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v0

    invoke-direct {p0, v10, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_2c
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->P:I

    if-eq v0, v2, :cond_2d

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->P:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    const/16 v0, 0x34

    sget v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_2d
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->T:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Q:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_2e

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Q:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->T:Ljava/lang/String;

    const/16 v0, 0x35

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->T:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_2e
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->U:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->R:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_2f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->R:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->U:Ljava/lang/String;

    const/16 v0, 0x46

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->U:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_2f
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->X:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->T:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_30

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->T:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->X:J

    const/16 v0, 0x37

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->X:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_30
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Y:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->U:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_31

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->U:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Y:J

    const/16 v0, 0x38

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Y:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_31
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->W:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->S:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_32

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->S:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->W:Ljava/lang/String;

    const/16 v0, 0x36

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->W:Ljava/lang/String;

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_32
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->Z:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->V:Z

    if-eq v0, v2, :cond_33

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->V:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->Z:Z

    const/16 v0, 0x39

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->V:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_33
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aa:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->W:Z

    if-eq v0, v2, :cond_34

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->W:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aa:Z

    const/16 v0, 0x57

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->W:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_34
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->a:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->X:I

    if-eq v0, v2, :cond_35

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->X:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->a:I

    const/16 v0, 0x58

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->X:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_35
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->ae:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Y:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_36

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Y:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->ae:J

    const/16 v0, 0x3d

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Y:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_36
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Z:I

    if-eq v0, v2, :cond_37

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Z:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    const/16 v0, 0x3f

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Z:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_37
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->z:Z

    iget-boolean v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aa:Z

    if-eq v0, v2, :cond_38

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aa:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->z:Z

    const/16 v0, 0x40

    sget-boolean v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->z:Z

    invoke-static {v2}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_38
    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->A:J

    iget-wide v4, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ab:J

    cmp-long v0, v2, v4

    if-eqz v0, :cond_39

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ab:J

    sput-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->A:J

    const/16 v0, 0x43

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->A:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_39
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ag:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ac:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3a

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ac:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ag:Ljava/lang/String;

    const/16 v0, 0x47

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->ag:Ljava/lang/String;

    invoke-virtual {v2}, Ljava/lang/String;->getBytes()[B

    move-result-object v2

    invoke-static {v2}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v2

    invoke-direct {p0, v0, v2}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_3a
    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ah:I

    iget v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ad:I

    if-eq v0, v2, :cond_3b

    invoke-virtual {p0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(Z)V

    iget v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ad:I

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ah:I

    const/16 v0, 0x48

    sget v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->ah:I

    invoke-static {v1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_3b
    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ab:J

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ae:J

    cmp-long v0, v0, v2

    if-eqz v0, :cond_3c

    iget-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ae:J

    sput-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ab:J

    const/16 v0, 0x49

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->ab:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_3c
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ac:Z

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->af:Z

    if-eq v0, v1, :cond_3d

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->af:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ac:Z

    const/16 v0, 0x4a

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->af:Z

    invoke-static {v1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_3d
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ad:Ljava/lang/String;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ag:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3e

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ag:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ad:Ljava/lang/String;

    const/16 v0, 0x4b

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->ad:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_3e
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->V:Ljava/lang/String;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ai:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3f

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ai:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->V:Ljava/lang/String;

    const/16 v0, 0x4d

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->V:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_3f
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aj:Z

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aj:Z

    if-eq v0, v1, :cond_40

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aj:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aj:Z

    const/16 v0, 0x4e

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aj:Z

    invoke-static {v1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_40
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ak:Z

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ak:Z

    if-eq v0, v1, :cond_41

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ak:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ak:Z

    const/16 v0, 0x4f

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ak:Z

    invoke-static {v1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_41
    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->al:Z

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->al:Z

    if-eq v0, v1, :cond_42

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->al:Z

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->al:Z

    const/16 v0, 0x50

    iget-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->al:Z

    invoke-static {v1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_42
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->am:Ljava/lang/String;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->am:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_43

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->am:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->am:Ljava/lang/String;

    const/16 v0, 0x51

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->am:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_43
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->an:Ljava/lang/String;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ah:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_44

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ah:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->an:Ljava/lang/String;

    const/16 v0, 0x55

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->an:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(I[B)V

    :cond_44
    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->x:J

    iget-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->an:J

    cmp-long v0, v0, v2

    if-eqz v0, :cond_45

    iget-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->an:J

    sput-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->x:J

    const/16 v0, 0x56

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->x:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    :cond_45
    return-void

    :cond_46
    move v0, v2

    goto/16 :goto_0
.end method


# virtual methods
.method public a(Z)V
    .locals 2

    sput-boolean p1, Lcom/igexin/push/extension/distribution/gbd/c/a;->ai:Z

    const/16 v0, 0x4c

    sget-boolean v1, Lcom/igexin/push/extension/distribution/gbd/c/a;->ai:Z

    invoke-static {v1}, Ljava/lang/String;->valueOf(Z)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->a(ILjava/lang/String;)V

    return-void
.end method

.method public a([B)V
    .locals 4

    :try_start_0
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, p1}, Ljava/lang/String;-><init>([B)V

    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, v0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    const-string v0, "GBD_ConfigDataManager"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "parse = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v2}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a()Lcom/igexin/push/extension/distribution/gbd/e/a/e;

    move-result-object v0

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    invoke-virtual {v0, v2, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->h(J)V

    const-string v0, "result"

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_51

    const-string v0, "ok"

    const-string v2, "result"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_51

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->b:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->b:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->c:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->c:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->d:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->d:Ljava/lang/String;

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->e:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->e:Z

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->f:J

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->g:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->g:J

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->h:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->h:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->i:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->i:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->j:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->j:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->k:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->k:I

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->l:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->l:J

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->m:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->m:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->o:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->n:I

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->q:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->o:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->r:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->p:Ljava/lang/String;

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->t:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->q:I

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->v:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->s:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->u:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->r:Ljava/lang/String;

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->w:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->t:J

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->p:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->u:Z

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->y:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->v:J

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->n:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->w:J

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->B:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->x:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->C:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->y:I

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->G:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->A:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->D:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->z:Ljava/lang/String;

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->K:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->B:Z

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->L:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->C:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->M:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->D:I

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->H:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->E:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->J:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->F:Ljava/lang/String;

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->I:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->G:I

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->s:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->H:Ljava/lang/String;

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->N:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->I:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->E:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->J:Ljava/lang/String;

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->O:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->K:Z

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->F:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->L:Z

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->P:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->N:J

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->O:I

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->P:I

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->T:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Q:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->U:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->R:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->W:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->S:Ljava/lang/String;

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->Z:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->V:Z

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aa:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->W:Z

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->a:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->X:I

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->X:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->T:J

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->Y:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->U:J

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->ae:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Y:J

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Z:I

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->z:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aa:Z

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->A:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ab:J

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ag:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ac:Ljava/lang/String;

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ah:I

    iput v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ad:I

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ac:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->af:Z

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->ab:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ae:J

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ad:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ag:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->V:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ai:Ljava/lang/String;

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aj:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aj:Z

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ak:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ak:Z

    sget-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->al:Z

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->al:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->am:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->am:Ljava/lang/String;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->an:Ljava/lang/String;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ah:Ljava/lang/String;

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/a;->x:J

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->an:J

    const-string v0, "tag"

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    const-string v0, "tag"

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->F:Ljava/lang/String;

    :cond_0
    const-string v0, "config"

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_51

    new-instance v0, Lorg/json/JSONObject;

    const-string v2, "config"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    const-string v1, "sdk.gbd.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2

    const-string v1, "sdk.gbd.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_1

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_2

    :cond_1
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->b:Z

    :cond_2
    const-string v1, "sdk.gbd.watchout.app"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3

    const-string v1, "sdk.gbd.watchout.app"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->c:Ljava/lang/String;

    :cond_3
    const-string v1, "sdk.gbd.watchout.service"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_4

    const-string v1, "sdk.gbd.watchout.service"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->d:Ljava/lang/String;

    :cond_4
    const-string v1, "sdk.gbd.coordinate"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_6

    const-string v1, "sdk.gbd.coordinate"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_5

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_6

    :cond_5
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->e:Z

    :cond_6
    const-string v1, "sdk.gbd.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_7

    const-string v1, "sdk.gbd.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->f:J

    :cond_7
    const-string v1, "sdk.gbd.wifi.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_8

    const-string v1, "sdk.gbd.wifi.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->g:J

    :cond_8
    const-string v1, "sdk.gbd.wifi.level"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_9

    const-string v1, "sdk.gbd.wifi.level"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->h:I

    :cond_9
    const-string v1, "sdk.gbd.wifi.timeout"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_a

    const-string v1, "sdk.gbd.wifi.timeout"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->i:I

    :cond_a
    const-string v1, "sdk.gbd.wifi.size"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_b

    const-string v1, "sdk.gbd.wifi.size"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->j:I

    :cond_b
    const-string v1, "sdk.gbd.wifi.changepercent"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_c

    const-string v1, "sdk.gbd.wifi.changepercent"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->k:I

    :cond_c
    const-string v1, "sdk.gbd.gps.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_d

    const-string v1, "sdk.gbd.gps.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    int-to-long v2, v1

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->l:J

    :cond_d
    const-string v1, "sdk.gbd.gps.distance"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_e

    const-string v1, "sdk.gbd.gps.distance"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->m:I

    :cond_e
    const-string v1, "sdk.gbd.ral.size"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_f

    const-string v1, "sdk.gbd.ral.size"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->n:I

    :cond_f
    const-string v1, "sdk.gbd.guard.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_10

    const-string v1, "sdk.gbd.guard.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->o:Z

    :cond_10
    const-string v1, "sdk.gbd.guard.services"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_11

    const-string v1, "sdk.gbd.guard.services"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->p:Ljava/lang/String;

    :cond_11
    const-string v1, "sdk.gbd.guard.count"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_12

    const-string v1, "sdk.gbd.guard.count"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->q:I

    :cond_12
    const-string v1, "sdk.gbd.guard.whitelist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_13

    const-string v1, "sdk.gbd.guard.whitelist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->s:Ljava/lang/String;

    :cond_13
    const-string v1, "sdk.gbd.guard.blacklist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_14

    const-string v1, "sdk.gbd.guard.blacklist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->r:Ljava/lang/String;

    :cond_14
    const-string v1, "gbd.guard.summary.duration"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_15

    const-string v1, "gbd.guard.summary.duration"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->t:J

    :cond_15
    const-string v1, "sdk.gbd.guardthirdparty.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_16

    const-string v1, "sdk.gbd.guardthirdparty.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getBoolean(Ljava/lang/String;)Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->u:Z

    :cond_16
    const-string v1, "sdk.gbd.guard.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_17

    const-string v1, "sdk.gbd.guard.freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->v:J

    :cond_17
    const-string v1, "sdk.gbd.gps.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_18

    const-string v1, "sdk.gbd.gps.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->w:J

    :cond_18
    const-string v1, "sdk.gbd.sysmem.limit"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_19

    const-string v1, "sdk.gbd.sysmem.limit"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->x:I

    :cond_19
    const-string v1, "sdk.gbd.appmem.limit"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1a

    const-string v1, "sdk.gbd.appmem.limit"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->y:I

    :cond_1a
    const-string v1, "sdk.gbd.recenttask.keyword"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1b

    const-string v1, "sdk.gbd.recenttask.keyword"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->z:Ljava/lang/String;

    :cond_1b
    const-string v1, "sdk.gbd.recenttask.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1d

    const-string v1, "sdk.gbd.recenttask.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_1c

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1d

    :cond_1c
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->A:Z

    :cond_1d
    const-string v1, "sdk.gbd.guardactivity.first"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_1f

    const-string v1, "sdk.gbd.guardactivity.first"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_1e

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_1f

    :cond_1e
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->B:Z

    :cond_1f
    const-string v1, "sdk.gbd.guardtask.starttime"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_20

    const-string v1, "sdk.gbd.guardtask.starttime"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->C:I

    :cond_20
    const-string v1, "sdk.gbd.guardtask.randomtime"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_21

    const-string v1, "sdk.gbd.guardtask.randomtime"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->D:I

    :cond_21
    const-string v1, "sdk.gbd.locate.request"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_23

    const-string v1, "sdk.gbd.locate.request"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_22

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_23

    :cond_22
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->E:Z

    :cond_23
    const-string v1, "sdk.gbd.locate.requesttime"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_24

    const-string v1, "sdk.gbd.locate.requesttime"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->G:I

    :cond_24
    const-string v1, "sdk.gbd.guard.intent"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_25

    const-string v1, "sdk.gbd.guard.intent"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->H:Ljava/lang/String;

    :cond_25
    const-string v1, "sdk.gbd.bluetooth.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_27

    const-string v1, "sdk.gbd.bluetooth.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_26

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_27

    :cond_26
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->I:Z

    :cond_27
    const-string v1, "sdk.gbd.systemapp.keyword"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_28

    const-string v1, "sdk.gbd.systemapp.keyword"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->J:Ljava/lang/String;

    :cond_28
    const-string v1, "sdk.gbd.guardlog.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2a

    const-string v1, "sdk.gbd.guardlog.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_29

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_2a

    :cond_29
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->K:Z

    :cond_2a
    const-string v1, "sdk.gbd.newrecenttask.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2c

    const-string v1, "sdk.gbd.newrecenttask.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_2b

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_2c

    :cond_2b
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->L:Z

    :cond_2c
    const-string v1, "sdk.gbd.mac.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2e

    const-string v1, "sdk.gbd.mac.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_2d

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_2e

    :cond_2d
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->M:Z

    :cond_2e
    const-string v1, "sdk.gbd.mac.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_2f

    const-string v1, "sdk.gbd.mac.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->N:J

    :cond_2f
    const-string v1, "sdk.gbd.mac.pingcount"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_30

    const-string v1, "sdk.gbd.mac.pingcount"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->O:I

    :cond_30
    const-string v1, "sdk.gbd.mac.reportcount"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_31

    const-string v1, "sdk.gbd.mac.reportcount"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->P:I

    :cond_31
    const-string v1, "sdk.gbd.guardgactivity.blacklist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_32

    const-string v1, "sdk.gbd.guardgactivity.blacklist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Q:Ljava/lang/String;

    :cond_32
    const-string v1, "sdk.gbd.guard.romandsdkint.blacklist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_33

    const-string v1, "sdk.gbd.guard.romandsdkint.blacklist"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->R:Ljava/lang/String;

    :cond_33
    const-string v1, "sdk.gbd.applist.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_35

    const-string v1, "sdk.gbd.applist.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_34

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_35

    :cond_34
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->V:Z

    :cond_35
    const-string v1, "sdk.gbd.sermd.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_37

    const-string v1, "sdk.gbd.sermd.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_36

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_37

    :cond_36
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->W:Z

    :cond_37
    const-string v1, "sdk.gbd.applist.runmax"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_38

    const-string v1, "sdk.gbd.applist.runmax"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->X:I

    :cond_38
    const-string v1, "sdk.gbd.applist.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_39

    const-string v1, "sdk.gbd.applist.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->T:J

    :cond_39
    const-string v1, "sdk.gbd.applistreport.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3a

    const-string v1, "sdk.gbd.applistreport.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->U:J

    :cond_3a
    const-string v1, "sdk.gbd.applist.channel"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3b

    const-string v1, "sdk.gbd.applist.channel"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->S:Ljava/lang/String;

    :cond_3b
    const-string v1, "sdk.gbd.guardservice.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3c

    const-string v1, "sdk.gbd.guardservice.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Y:J

    :cond_3c
    const-string v1, "sdk.gbd.http.maxsize"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3d

    const-string v1, "sdk.gbd.http.maxsize"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->Z:I

    :cond_3d
    const-string v1, "sdk.gbd.lf_enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3f

    const-string v1, "sdk.gbd.lf_enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_3e

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_3f

    :cond_3e
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aa:Z

    :cond_3f
    const-string v1, "sdk.gbd.lf_freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_40

    const-string v1, "sdk.gbd.lf_freq"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ab:J

    :cond_40
    const-string v1, "sdk.gbd.app_list_url"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_41

    const-string v1, "sdk.gbd.app_list_url"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ac:Ljava/lang/String;

    :cond_41
    const-string v1, "sdk.gbd.app_list_version"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_42

    const-string v1, "sdk.gbd.app_list_version"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v1

    iput v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ad:I

    :cond_42
    const-string v1, "sdk.gbd.target_app_list.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_44

    const-string v1, "sdk.gbd.target_app_list.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_43

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_44

    :cond_43
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->af:Z

    :cond_44
    const-string v1, "sdk.gbd.target_app_list.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_45

    const-string v1, "sdk.gbd.target_app_list.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    iput-wide v2, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ae:J

    :cond_45
    const-string v1, "sdk.gbd.target_app_list"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_46

    const-string v1, "sdk.gbd.target_app_list"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ag:Ljava/lang/String;

    :cond_46
    const-string v1, "sdk.gbd.pm_black_list"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_47

    const-string v1, "sdk.gbd.pm_black_list"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ai:Ljava/lang/String;

    :cond_47
    const-string v1, "sdk.gbd.activity.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_49

    const-string v1, "sdk.gbd.activity.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_48

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_49

    :cond_48
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->aj:Z

    :cond_49
    const-string v1, "sdk.gbd.service.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_4b

    const-string v1, "sdk.gbd.service.enable"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4a

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_4b

    :cond_4a
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ak:Z

    :cond_4b
    const-string v1, "sdk.gbd.force.start"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_4d

    const-string v1, "sdk.gbd.force.start"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "true"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_4c

    const-string v2, "false"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_4d

    :cond_4c
    invoke-static {v1}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v1

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->al:Z

    :cond_4d
    const-string v1, "sdk.gbd.force.start.target"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_4e

    const-string v1, "sdk.gbd.force.start.target"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->am:Ljava/lang/String;

    :cond_4e
    const-string v1, "sdk.gbd.permission.config"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_4f

    const-string v1, "sdk.gbd.permission.config"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->ah:Ljava/lang/String;

    :cond_4f
    const-string v1, "sdk.gbd.newrecent.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_50

    const-string v1, "sdk.gbd.newrecent.interval"

    invoke-virtual {v0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v0

    iput-wide v0, p0, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->an:J

    :cond_50
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/e/a/a;->c()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_51
    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    const-string v1, "GBD_ConfigDataManager"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method

.method public b()V
    .locals 10

    const/4 v1, 0x0

    const-wide/16 v8, 0x0

    :try_start_0
    const-string v0, "select key, value from config order by value"

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->b:Lcom/igexin/push/extension/distribution/gbd/e/a;

    const/4 v3, 0x0

    invoke-virtual {v2, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a;->a(Ljava/lang/String;[Ljava/lang/String;)Landroid/database/Cursor;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    move-result-object v3

    if-eqz v3, :cond_c

    move-object v2, v1

    :goto_0
    :try_start_1
    invoke-interface {v3}, Landroid/database/Cursor;->moveToNext()Z

    move-result v0

    if-eqz v0, :cond_c

    const-string v0, "key"

    invoke-interface {v3, v0}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v0

    invoke-interface {v3, v0}, Landroid/database/Cursor;->getInt(I)I

    move-result v4

    const-string v0, "GBD_ConfigDataManager"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "db key = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v0, v5}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    const/4 v0, 0x1

    if-eq v4, v0, :cond_0

    const/4 v0, 0x2

    if-eq v4, v0, :cond_0

    const/16 v0, 0xf

    if-eq v4, v0, :cond_0

    const/16 v0, 0x11

    if-eq v4, v0, :cond_0

    const/16 v0, 0x12

    if-eq v4, v0, :cond_0

    const/16 v0, 0x1d

    if-eq v4, v0, :cond_0

    const/16 v0, 0x23

    if-eq v4, v0, :cond_0

    const/16 v0, 0x26

    if-eq v4, v0, :cond_0

    const/16 v0, 0x29

    if-eq v4, v0, :cond_0

    const/16 v0, 0x35

    if-eq v4, v0, :cond_0

    const/16 v0, 0x46

    if-eq v4, v0, :cond_0

    const/16 v0, 0x47

    if-eq v4, v0, :cond_0

    const/16 v0, 0x4b

    if-eq v4, v0, :cond_0

    const/16 v0, 0x4d

    if-eq v4, v0, :cond_0

    const/16 v0, 0x51

    if-eq v4, v0, :cond_0

    const/16 v0, 0x55

    if-ne v4, v0, :cond_1

    :cond_0
    :try_start_2
    const-string v0, "value"

    invoke-interface {v3, v0}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v0

    invoke-interface {v3, v0}, Landroid/database/Cursor;->getBlob(I)[B

    move-result-object v2

    if-eqz v2, :cond_d

    invoke-static {v2}, Lcom/igexin/b/b/a;->c([B)[B

    move-result-object v0

    :goto_1
    if-nez v0, :cond_e

    move-object v2, v0

    goto :goto_0

    :cond_1
    const-string v0, "value"

    invoke-interface {v3, v0}, Landroid/database/Cursor;->getColumnIndex(Ljava/lang/String;)I

    move-result v0

    invoke-interface {v3, v0}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_1
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    move-result-object v0

    :goto_2
    packed-switch v4, :pswitch_data_0

    :pswitch_0
    goto/16 :goto_0

    :pswitch_1
    :try_start_3
    invoke-static {v0}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->b:Z
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_0
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    goto/16 :goto_0

    :catch_0
    move-exception v0

    move-object v1, v3

    :goto_3
    :try_start_4
    const-string v2, "GBD_ConfigDataManager"

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v2, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_2

    if-eqz v1, :cond_2

    invoke-interface {v1}, Landroid/database/Cursor;->close()V

    :cond_2
    :goto_4
    return-void

    :catch_1
    move-exception v0

    :try_start_5
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_0
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    goto/16 :goto_0

    :catchall_0
    move-exception v0

    :goto_5
    if-eqz v3, :cond_3

    invoke-interface {v3}, Landroid/database/Cursor;->close()V

    :cond_3
    throw v0

    :pswitch_2
    :try_start_6
    invoke-static {v0}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->H:Z

    goto/16 :goto_0

    :pswitch_3
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->c:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_4
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->d:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_5
    invoke-static {v0}, Ljava/lang/Boolean;->parseBoolean(Ljava/lang/String;)Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->e:Z

    goto/16 :goto_0

    :pswitch_6
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v4, v4, v8

    if-gtz v4, :cond_4

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    :goto_6
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->f:J

    goto/16 :goto_0

    :cond_4
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    goto :goto_6

    :pswitch_7
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v4, v4, v8

    if-gtz v4, :cond_5

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->g:J

    :goto_7
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->g:J

    goto/16 :goto_0

    :cond_5
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    goto :goto_7

    :pswitch_8
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->h:I

    goto/16 :goto_0

    :pswitch_9
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->i:I

    goto/16 :goto_0

    :pswitch_a
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->j:I

    goto/16 :goto_0

    :pswitch_b
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->k:I

    goto/16 :goto_0

    :pswitch_c
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v4, v4, v8

    if-gtz v4, :cond_6

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->l:J

    :goto_8
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->l:J

    goto/16 :goto_0

    :cond_6
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    goto :goto_8

    :pswitch_d
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->m:I

    goto/16 :goto_0

    :pswitch_e
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->o:I

    goto/16 :goto_0

    :pswitch_f
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->q:Z

    goto/16 :goto_0

    :pswitch_10
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->r:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_11
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->t:I

    goto/16 :goto_0

    :pswitch_12
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->v:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_13
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->u:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_14
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->w:J

    goto/16 :goto_0

    :pswitch_15
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->p:Z

    goto/16 :goto_0

    :pswitch_16
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v4, v4, v8

    if-gtz v4, :cond_7

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->y:J

    :goto_9
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->y:J

    goto/16 :goto_0

    :cond_7
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    goto :goto_9

    :pswitch_17
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->n:J

    goto/16 :goto_0

    :pswitch_18
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->B:I

    goto/16 :goto_0

    :pswitch_19
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->C:I

    goto/16 :goto_0

    :pswitch_1a
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->G:Z

    goto/16 :goto_0

    :pswitch_1b
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->D:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_1c
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->J:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_1d
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->K:Z

    goto/16 :goto_0

    :pswitch_1e
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->L:I

    goto/16 :goto_0

    :pswitch_1f
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->M:I

    goto/16 :goto_0

    :pswitch_20
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->I:I

    goto/16 :goto_0

    :pswitch_21
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->s:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_22
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->N:Z

    goto/16 :goto_0

    :pswitch_23
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->E:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_24
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->O:Z

    goto/16 :goto_0

    :pswitch_25
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->F:Z

    goto/16 :goto_0

    :pswitch_26
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->P:Z

    goto/16 :goto_0

    :pswitch_27
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v0, v4, v8

    if-gtz v0, :cond_8

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    :cond_8
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->Q:J

    goto/16 :goto_0

    :pswitch_28
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->R:I

    goto/16 :goto_0

    :pswitch_29
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->S:I

    goto/16 :goto_0

    :pswitch_2a
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->T:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_2b
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->U:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_2c
    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->W:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_2d
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->X:J

    goto/16 :goto_0

    :pswitch_2e
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->Y:J

    goto/16 :goto_0

    :pswitch_2f
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->Z:Z

    goto/16 :goto_0

    :pswitch_30
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aa:Z

    goto/16 :goto_0

    :pswitch_31
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->a:I

    goto/16 :goto_0

    :pswitch_32
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->ae:J

    goto/16 :goto_0

    :pswitch_33
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Integer;->intValue()I

    move-result v4

    if-gtz v4, :cond_9

    sget v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    :goto_a
    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->af:I

    goto/16 :goto_0

    :cond_9
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    goto :goto_a

    :pswitch_34
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->z:Z

    goto/16 :goto_0

    :pswitch_35
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v4, v4, v8

    if-gtz v4, :cond_a

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->A:J

    :goto_b
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->A:J

    goto/16 :goto_0

    :cond_a
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    goto :goto_b

    :pswitch_36
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ag:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_37
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ah:I

    goto/16 :goto_0

    :pswitch_38
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->ab:J

    goto/16 :goto_0

    :pswitch_39
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ac:Z

    goto/16 :goto_0

    :pswitch_3a
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ad:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_3b
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ai:Z

    goto/16 :goto_0

    :pswitch_3c
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->V:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_3d
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->aj:Z

    goto/16 :goto_0

    :pswitch_3e
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->ak:Z

    goto/16 :goto_0

    :pswitch_3f
    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Ljava/lang/String;)Ljava/lang/Boolean;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    sput-boolean v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->al:Z

    goto/16 :goto_0

    :pswitch_40
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->am:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_41
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/a;->an:Ljava/lang/String;

    goto/16 :goto_0

    :pswitch_42
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    cmp-long v4, v4, v8

    if-gtz v4, :cond_b

    sget-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->x:J

    :goto_c
    sput-wide v4, Lcom/igexin/push/extension/distribution/gbd/c/a;->x:J

    goto/16 :goto_0

    :cond_b
    invoke-static {v0}, Ljava/lang/Long;->valueOf(Ljava/lang/String;)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J
    :try_end_6
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_0
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    move-result-wide v4

    goto :goto_c

    :cond_c
    if-eqz v3, :cond_2

    invoke-interface {v3}, Landroid/database/Cursor;->close()V

    goto/16 :goto_4

    :catchall_1
    move-exception v0

    move-object v3, v1

    goto/16 :goto_5

    :catchall_2
    move-exception v0

    move-object v3, v1

    goto/16 :goto_5

    :catch_2
    move-exception v0

    goto/16 :goto_3

    :cond_d
    move-object v0, v2

    goto/16 :goto_1

    :cond_e
    move-object v2, v0

    move-object v0, v1

    goto/16 :goto_2

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_1
        :pswitch_3
        :pswitch_4
        :pswitch_5
        :pswitch_6
        :pswitch_7
        :pswitch_8
        :pswitch_9
        :pswitch_a
        :pswitch_b
        :pswitch_c
        :pswitch_d
        :pswitch_e
        :pswitch_0
        :pswitch_f
        :pswitch_10
        :pswitch_11
        :pswitch_13
        :pswitch_12
        :pswitch_14
        :pswitch_15
        :pswitch_16
        :pswitch_17
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_18
        :pswitch_19
        :pswitch_1b
        :pswitch_1a
        :pswitch_1d
        :pswitch_1e
        :pswitch_1f
        :pswitch_2
        :pswitch_1c
        :pswitch_20
        :pswitch_0
        :pswitch_21
        :pswitch_22
        :pswitch_0
        :pswitch_23
        :pswitch_0
        :pswitch_0
        :pswitch_24
        :pswitch_0
        :pswitch_25
        :pswitch_0
        :pswitch_26
        :pswitch_27
        :pswitch_28
        :pswitch_0
        :pswitch_29
        :pswitch_2a
        :pswitch_2c
        :pswitch_2d
        :pswitch_2e
        :pswitch_2f
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_32
        :pswitch_0
        :pswitch_33
        :pswitch_34
        :pswitch_0
        :pswitch_0
        :pswitch_35
        :pswitch_0
        :pswitch_0
        :pswitch_2b
        :pswitch_36
        :pswitch_37
        :pswitch_38
        :pswitch_39
        :pswitch_3a
        :pswitch_3b
        :pswitch_3c
        :pswitch_3d
        :pswitch_3e
        :pswitch_3f
        :pswitch_40
        :pswitch_0
        :pswitch_0
        :pswitch_0
        :pswitch_41
        :pswitch_42
        :pswitch_30
        :pswitch_31
    .end packed-switch
.end method
