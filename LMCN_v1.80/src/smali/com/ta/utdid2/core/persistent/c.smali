.class public final Lcom/ta/utdid2/core/persistent/c;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field private static final a:Ljava/lang/String; = "t"

.field private static final b:Ljava/lang/String; = "t2"


# instance fields
.field private c:Ljava/lang/String;

.field private d:Ljava/lang/String;

.field private e:Z

.field private f:Z

.field private g:Z

.field private h:Landroid/content/SharedPreferences;

.field private i:Lcom/ta/utdid2/core/persistent/b;

.field private j:Landroid/content/SharedPreferences$Editor;

.field private k:Lcom/ta/utdid2/core/persistent/b$a;

.field private l:Landroid/content/Context;

.field private m:Lcom/ta/utdid2/core/persistent/d;

.field private n:Z


# direct methods
.method public constructor <init>(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V
    .locals 12

    .prologue
    const/4 v7, 0x1

    const/4 v4, 0x0

    const/4 v6, 0x0

    const-wide/16 v2, 0x0

    .line 33
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 20
    const-string v0, ""

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    .line 21
    const-string v0, ""

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->d:Ljava/lang/String;

    .line 22
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->e:Z

    .line 23
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->f:Z

    .line 24
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->g:Z

    .line 25
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    .line 26
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    .line 27
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    .line 28
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    .line 29
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->l:Landroid/content/Context;

    .line 30
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    .line 31
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->n:Z

    .line 35
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->e:Z

    .line 36
    iput-boolean v7, p0, Lcom/ta/utdid2/core/persistent/c;->n:Z

    .line 37
    iput-object p3, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    .line 38
    iput-object p2, p0, Lcom/ta/utdid2/core/persistent/c;->d:Ljava/lang/String;

    .line 39
    iput-object p1, p0, Lcom/ta/utdid2/core/persistent/c;->l:Landroid/content/Context;

    .line 42
    if-eqz p1, :cond_d

    .line 44
    invoke-virtual {p1, p3, v6}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 43
    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    .line 45
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    const-string v1, "t"

    invoke-interface {v0, v1, v2, v3}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v0

    .line 49
    :goto_0
    :try_start_0
    invoke-static {}, Landroid/os/Environment;->getExternalStorageState()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v4

    .line 53
    :goto_1
    invoke-static {v4}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v5

    if-nez v5, :cond_7

    .line 56
    const-string v5, "mounted"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v5

    if-eqz v5, :cond_6

    .line 57
    iput-boolean v7, p0, Lcom/ta/utdid2/core/persistent/c;->g:Z

    iput-boolean v7, p0, Lcom/ta/utdid2/core/persistent/c;->f:Z

    .line 66
    :goto_2
    iget-boolean v4, p0, Lcom/ta/utdid2/core/persistent/c;->f:Z

    if-nez v4, :cond_0

    iget-boolean v4, p0, Lcom/ta/utdid2/core/persistent/c;->g:Z

    if-eqz v4, :cond_c

    .line 67
    :cond_0
    if-eqz p1, :cond_c

    .line 68
    invoke-static {p2}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v4

    if-nez v4, :cond_c

    .line 69
    invoke-direct {p0, p2}, Lcom/ta/utdid2/core/persistent/c;->c(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/d;

    move-result-object v4

    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    .line 70
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    if-eqz v4, :cond_c

    .line 72
    :try_start_1
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    .line 73
    invoke-virtual {v4, p3}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v4

    .line 72
    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    .line 75
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    const-string v5, "t"

    invoke-interface {v4, v5}, Lcom/ta/utdid2/core/persistent/b;->b(Ljava/lang/String;)J
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_3

    move-result-wide v4

    .line 95
    :try_start_2
    iget-object v6, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    const-string v7, "t2"

    const-wide/16 v8, 0x0

    invoke-interface {v6, v7, v8, v9}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_4

    move-result-wide v6

    .line 96
    :try_start_3
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    const-string v1, "t2"

    invoke-interface {v0, v1}, Lcom/ta/utdid2/core/persistent/b;->b(Ljava/lang/String;)J
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_5

    move-result-wide v0

    .line 97
    cmp-long v4, v6, v0

    if-gez v4, :cond_8

    cmp-long v4, v6, v2

    if-lez v4, :cond_8

    .line 99
    :try_start_4
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    iget-object v5, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-static {v4, v5}, Lcom/ta/utdid2/core/persistent/c;->a(Landroid/content/SharedPreferences;Lcom/ta/utdid2/core/persistent/b;)V

    .line 100
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    invoke-virtual {v4, p3}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v4

    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;
    :try_end_4
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_1

    .line 131
    :cond_1
    :goto_3
    cmp-long v4, v6, v0

    if-nez v4, :cond_2

    cmp-long v4, v6, v2

    if-nez v4, :cond_5

    cmp-long v4, v0, v2

    if-nez v4, :cond_5

    .line 132
    :cond_2
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    .line 133
    iget-boolean v8, p0, Lcom/ta/utdid2/core/persistent/c;->n:Z

    if-eqz v8, :cond_3

    .line 134
    iget-boolean v8, p0, Lcom/ta/utdid2/core/persistent/c;->n:Z

    if-eqz v8, :cond_5

    cmp-long v6, v6, v2

    if-nez v6, :cond_5

    cmp-long v0, v0, v2

    if-nez v0, :cond_5

    .line 135
    :cond_3
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v0, :cond_4

    .line 136
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    .line 137
    const-string v1, "t2"

    invoke-interface {v0, v1, v4, v5}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    .line 138
    invoke-interface {v0}, Landroid/content/SharedPreferences$Editor;->commit()Z

    .line 141
    :cond_4
    :try_start_5
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v0, :cond_5

    .line 142
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0}, Lcom/ta/utdid2/core/persistent/b;->c()Lcom/ta/utdid2/core/persistent/b$a;

    move-result-object v0

    .line 143
    const-string v1, "t2"

    invoke-interface {v0, v1, v4, v5}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;J)Lcom/ta/utdid2/core/persistent/b$a;

    .line 144
    invoke-interface {v0}, Lcom/ta/utdid2/core/persistent/b$a;->b()Z
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_2

    .line 151
    :cond_5
    :goto_4
    return-void

    .line 51
    :catch_0
    move-exception v5

    invoke-virtual {v5}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_1

    .line 59
    :cond_6
    const-string v5, "mounted_ro"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_7

    .line 60
    iput-boolean v7, p0, Lcom/ta/utdid2/core/persistent/c;->f:Z

    .line 61
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->g:Z

    goto/16 :goto_2

    .line 63
    :cond_7
    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->g:Z

    iput-boolean v6, p0, Lcom/ta/utdid2/core/persistent/c;->f:Z

    goto/16 :goto_2

    .line 103
    :cond_8
    cmp-long v4, v6, v0

    if-lez v4, :cond_9

    cmp-long v4, v0, v2

    if-lez v4, :cond_9

    .line 105
    :try_start_6
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    iget-object v5, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-static {v4, v5}, Lcom/ta/utdid2/core/persistent/c;->a(Lcom/ta/utdid2/core/persistent/b;Landroid/content/SharedPreferences;)V

    .line 107
    const/4 v4, 0x0

    .line 106
    invoke-virtual {p1, p3, v4}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v4

    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    goto :goto_3

    :catch_1
    move-exception v4

    move-wide v4, v6

    :goto_5
    move-wide v6, v4

    goto :goto_3

    .line 108
    :cond_9
    cmp-long v4, v6, v2

    if-nez v4, :cond_a

    cmp-long v4, v0, v2

    if-lez v4, :cond_a

    .line 109
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    iget-object v5, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-static {v4, v5}, Lcom/ta/utdid2/core/persistent/c;->a(Lcom/ta/utdid2/core/persistent/b;Landroid/content/SharedPreferences;)V

    .line 111
    const/4 v4, 0x0

    .line 110
    invoke-virtual {p1, p3, v4}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v4

    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    goto/16 :goto_3

    .line 112
    :cond_a
    cmp-long v4, v0, v2

    if-nez v4, :cond_b

    cmp-long v4, v6, v2

    if-lez v4, :cond_b

    .line 113
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    iget-object v5, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-static {v4, v5}, Lcom/ta/utdid2/core/persistent/c;->a(Landroid/content/SharedPreferences;Lcom/ta/utdid2/core/persistent/b;)V

    .line 114
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    invoke-virtual {v4, p3}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v4

    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    goto/16 :goto_3

    .line 117
    :cond_b
    cmp-long v4, v6, v0

    if-nez v4, :cond_1

    .line 118
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    iget-object v5, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-static {v4, v5}, Lcom/ta/utdid2/core/persistent/c;->a(Landroid/content/SharedPreferences;Lcom/ta/utdid2/core/persistent/b;)V

    .line 119
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    invoke-virtual {v4, p3}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v4

    iput-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;
    :try_end_6
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_1

    goto/16 :goto_3

    :catch_2
    move-exception v0

    goto :goto_4

    :catch_3
    move-exception v4

    move-wide v4, v0

    move-wide v0, v2

    goto :goto_5

    :catch_4
    move-exception v6

    move-wide v10, v4

    move-wide v4, v0

    move-wide v0, v10

    goto :goto_5

    :catch_5
    move-exception v0

    move-wide v0, v4

    move-wide v4, v6

    goto :goto_5

    :cond_c
    move-wide v6, v0

    move-wide v0, v2

    goto/16 :goto_3

    :cond_d
    move-wide v0, v2

    goto/16 :goto_0
.end method

.method private static a(Landroid/content/SharedPreferences;Lcom/ta/utdid2/core/persistent/b;)V
    .locals 6

    .prologue
    .line 176
    if-eqz p0, :cond_1

    if-eqz p1, :cond_1

    .line 177
    invoke-interface {p1}, Lcom/ta/utdid2/core/persistent/b;->c()Lcom/ta/utdid2/core/persistent/b$a;

    move-result-object v2

    .line 179
    invoke-interface {v2}, Lcom/ta/utdid2/core/persistent/b$a;->a()Lcom/ta/utdid2/core/persistent/b$a;

    .line 180
    invoke-interface {p0}, Landroid/content/SharedPreferences;->getAll()Ljava/util/Map;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    .line 181
    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-nez v0, :cond_2

    .line 198
    invoke-interface {v2}, Lcom/ta/utdid2/core/persistent/b$a;->b()Z

    .line 201
    :cond_1
    return-void

    .line 182
    :cond_2
    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 183
    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 184
    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v0

    .line 185
    instance-of v4, v0, Ljava/lang/String;

    if-eqz v4, :cond_3

    .line 186
    check-cast v0, Ljava/lang/String;

    invoke-interface {v2, v1, v0}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b$a;

    goto :goto_0

    .line 187
    :cond_3
    instance-of v4, v0, Ljava/lang/Integer;

    if-eqz v4, :cond_4

    .line 188
    check-cast v0, Ljava/lang/Integer;

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    invoke-interface {v2, v1, v0}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;I)Lcom/ta/utdid2/core/persistent/b$a;

    goto :goto_0

    .line 189
    :cond_4
    instance-of v4, v0, Ljava/lang/Long;

    if-eqz v4, :cond_5

    .line 190
    check-cast v0, Ljava/lang/Long;

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    invoke-interface {v2, v1, v4, v5}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;J)Lcom/ta/utdid2/core/persistent/b$a;

    goto :goto_0

    .line 191
    :cond_5
    instance-of v4, v0, Ljava/lang/Float;

    if-eqz v4, :cond_6

    .line 192
    check-cast v0, Ljava/lang/Float;

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v0

    invoke-interface {v2, v1, v0}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;F)Lcom/ta/utdid2/core/persistent/b$a;

    goto :goto_0

    .line 193
    :cond_6
    instance-of v4, v0, Ljava/lang/Boolean;

    if-eqz v4, :cond_0

    .line 195
    check-cast v0, Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    .line 194
    invoke-interface {v2, v1, v0}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;Z)Lcom/ta/utdid2/core/persistent/b$a;

    goto :goto_0
.end method

.method private static a(Lcom/ta/utdid2/core/persistent/b;Landroid/content/SharedPreferences;)V
    .locals 6

    .prologue
    .line 204
    if-eqz p0, :cond_1

    if-eqz p1, :cond_1

    .line 205
    invoke-interface {p1}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v2

    .line 206
    if-eqz v2, :cond_1

    .line 207
    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->clear()Landroid/content/SharedPreferences$Editor;

    .line 208
    invoke-interface {p0}, Lcom/ta/utdid2/core/persistent/b;->b()Ljava/util/Map;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    .line 209
    :cond_0
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-nez v0, :cond_2

    .line 226
    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->commit()Z

    .line 229
    :cond_1
    return-void

    .line 210
    :cond_2
    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/util/Map$Entry;

    .line 211
    invoke-interface {v0}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 212
    invoke-interface {v0}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v0

    .line 213
    instance-of v4, v0, Ljava/lang/String;

    if-eqz v4, :cond_3

    .line 214
    check-cast v0, Ljava/lang/String;

    invoke-interface {v2, v1, v0}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    goto :goto_0

    .line 215
    :cond_3
    instance-of v4, v0, Ljava/lang/Integer;

    if-eqz v4, :cond_4

    .line 216
    check-cast v0, Ljava/lang/Integer;

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    invoke-interface {v2, v1, v0}, Landroid/content/SharedPreferences$Editor;->putInt(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;

    goto :goto_0

    .line 217
    :cond_4
    instance-of v4, v0, Ljava/lang/Long;

    if-eqz v4, :cond_5

    .line 218
    check-cast v0, Ljava/lang/Long;

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    invoke-interface {v2, v1, v4, v5}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    goto :goto_0

    .line 219
    :cond_5
    instance-of v4, v0, Ljava/lang/Float;

    if-eqz v4, :cond_6

    .line 220
    check-cast v0, Ljava/lang/Float;

    invoke-virtual {v0}, Ljava/lang/Float;->floatValue()F

    move-result v0

    invoke-interface {v2, v1, v0}, Landroid/content/SharedPreferences$Editor;->putFloat(Ljava/lang/String;F)Landroid/content/SharedPreferences$Editor;

    goto :goto_0

    .line 221
    :cond_6
    instance-of v4, v0, Ljava/lang/Boolean;

    if-eqz v4, :cond_0

    .line 223
    check-cast v0, Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    .line 222
    invoke-interface {v2, v1, v0}, Landroid/content/SharedPreferences$Editor;->putBoolean(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;

    goto :goto_0
.end method

.method private a(Ljava/lang/String;F)V
    .locals 1

    .prologue
    .line 289
    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    const-string v0, "t"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 290
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 291
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v0, :cond_0

    .line 292
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0, p1, p2}, Landroid/content/SharedPreferences$Editor;->putFloat(Ljava/lang/String;F)Landroid/content/SharedPreferences$Editor;

    .line 294
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v0, :cond_1

    .line 295
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v0, p1, p2}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;F)Lcom/ta/utdid2/core/persistent/b$a;

    .line 298
    :cond_1
    return-void
.end method

.method private a(Ljava/lang/String;I)V
    .locals 1

    .prologue
    .line 253
    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    const-string v0, "t"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 254
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 255
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v0, :cond_0

    .line 256
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0, p1, p2}, Landroid/content/SharedPreferences$Editor;->putInt(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;

    .line 258
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v0, :cond_1

    .line 259
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v0, p1, p2}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;I)Lcom/ta/utdid2/core/persistent/b$a;

    .line 262
    :cond_1
    return-void
.end method

.method private a(Ljava/lang/String;J)V
    .locals 2

    .prologue
    .line 265
    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    const-string v0, "t"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 266
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 267
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v0, :cond_0

    .line 268
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0, p1, p2, p3}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    .line 270
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v0, :cond_1

    .line 271
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v0, p1, p2, p3}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;J)Lcom/ta/utdid2/core/persistent/b$a;

    .line 274
    :cond_1
    return-void
.end method

.method private a(Ljava/lang/String;Z)V
    .locals 1

    .prologue
    .line 277
    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    const-string v0, "t"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 278
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 279
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v0, :cond_0

    .line 280
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0, p1, p2}, Landroid/content/SharedPreferences$Editor;->putBoolean(Ljava/lang/String;Z)Landroid/content/SharedPreferences$Editor;

    .line 282
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v0, :cond_1

    .line 283
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v0, p1, p2}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;Z)Lcom/ta/utdid2/core/persistent/b$a;

    .line 286
    :cond_1
    return-void
.end method

.method private b()Z
    .locals 1

    .prologue
    .line 232
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v0, :cond_1

    .line 233
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0}, Lcom/ta/utdid2/core/persistent/b;->a()Z

    move-result v0

    .line 234
    if-nez v0, :cond_0

    .line 235
    invoke-virtual {p0}, Lcom/ta/utdid2/core/persistent/c;->a()Z

    .line 239
    :cond_0
    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private c(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/d;
    .locals 6

    .prologue
    const/4 v0, 0x0

    .line 1163
    invoke-static {}, Landroid/os/Environment;->getExternalStorageDirectory()Ljava/io/File;

    move-result-object v2

    .line 1164
    if-eqz v2, :cond_2

    .line 1165
    new-instance v1, Ljava/io/File;

    const-string v3, "%s%s%s"

    const/4 v4, 0x3

    new-array v4, v4, [Ljava/lang/Object;

    const/4 v5, 0x0

    .line 1166
    invoke-virtual {v2}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v2

    aput-object v2, v4, v5

    const/4 v2, 0x1

    sget-object v5, Ljava/io/File;->separator:Ljava/lang/String;

    aput-object v5, v4, v2

    const/4 v2, 0x2

    aput-object p1, v4, v2

    .line 1165
    invoke-static {v3, v4}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 1167
    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v2

    if-nez v2, :cond_0

    .line 1168
    invoke-virtual {v1}, Ljava/io/File;->mkdirs()Z

    .line 155
    :cond_0
    :goto_0
    if-eqz v1, :cond_1

    .line 156
    new-instance v0, Lcom/ta/utdid2/core/persistent/d;

    invoke-virtual {v1}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/ta/utdid2/core/persistent/d;-><init>(Ljava/lang/String;)V

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    .line 157
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    .line 159
    :cond_1
    return-object v0

    :cond_2
    move-object v1, v0

    .line 1172
    goto :goto_0
.end method

.method private c()V
    .locals 1

    .prologue
    .line 243
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v0, :cond_0

    .line 244
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v0}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;

    move-result-object v0

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    .line 246
    :cond_0
    iget-boolean v0, p0, Lcom/ta/utdid2/core/persistent/c;->g:Z

    if-eqz v0, :cond_1

    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v0, :cond_1

    .line 247
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0}, Lcom/ta/utdid2/core/persistent/b;->c()Lcom/ta/utdid2/core/persistent/b$a;

    move-result-object v0

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    .line 249
    :cond_1
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 250
    return-void
.end method

.method private static d(Ljava/lang/String;)Ljava/io/File;
    .locals 5

    .prologue
    .line 163
    invoke-static {}, Landroid/os/Environment;->getExternalStorageDirectory()Ljava/io/File;

    move-result-object v1

    .line 164
    if-eqz v1, :cond_1

    .line 165
    new-instance v0, Ljava/io/File;

    const-string v2, "%s%s%s"

    const/4 v3, 0x3

    new-array v3, v3, [Ljava/lang/Object;

    const/4 v4, 0x0

    .line 166
    invoke-virtual {v1}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v1

    aput-object v1, v3, v4

    const/4 v1, 0x1

    sget-object v4, Ljava/io/File;->separator:Ljava/lang/String;

    aput-object v4, v3, v1

    const/4 v1, 0x2

    aput-object p0, v3, v1

    .line 165
    invoke-static {v2, v3}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 167
    invoke-virtual {v0}, Ljava/io/File;->exists()Z

    move-result v1

    if-nez v1, :cond_0

    .line 168
    invoke-virtual {v0}, Ljava/io/File;->mkdirs()Z

    .line 172
    :cond_0
    :goto_0
    return-object v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private d()V
    .locals 3

    .prologue
    .line 325
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v0, :cond_0

    .line 326
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->l:Landroid/content/Context;

    if-eqz v0, :cond_0

    .line 327
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->l:Landroid/content/Context;

    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    .line 328
    const/4 v2, 0x0

    .line 327
    invoke-virtual {v0, v1, v2}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v0

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    .line 331
    :cond_0
    const/4 v0, 0x0

    .line 333
    :try_start_0
    invoke-static {}, Landroid/os/Environment;->getExternalStorageState()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 337
    :goto_0
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_2

    .line 338
    const-string v1, "mounted"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_1

    .line 340
    const-string v1, "mounted_ro"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 341
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v0, :cond_2

    .line 343
    :cond_1
    :try_start_1
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    if-eqz v0, :cond_2

    .line 344
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    invoke-virtual {v0, v1}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v0

    iput-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 352
    :cond_2
    :goto_1
    return-void

    .line 335
    :catch_0
    move-exception v1

    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    :catch_1
    move-exception v0

    goto :goto_1
.end method

.method private e(Ljava/lang/String;)I
    .locals 2

    .prologue
    const/4 v0, 0x0

    .line 447
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 448
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v1, :cond_1

    .line 449
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v1, p1, v0}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I

    move-result v0

    .line 453
    :cond_0
    :goto_0
    return v0

    .line 450
    :cond_1
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v1, :cond_0

    .line 451
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0, p1}, Lcom/ta/utdid2/core/persistent/b;->a(Ljava/lang/String;)I

    move-result v0

    goto :goto_0
.end method

.method private e()V
    .locals 4

    .prologue
    .line 355
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 356
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    .line 357
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v2, :cond_0

    .line 358
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->clear()Landroid/content/SharedPreferences$Editor;

    .line 359
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    const-string v3, "t"

    invoke-interface {v2, v3, v0, v1}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    .line 361
    :cond_0
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v2, :cond_1

    .line 362
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v2}, Lcom/ta/utdid2/core/persistent/b$a;->a()Lcom/ta/utdid2/core/persistent/b$a;

    .line 363
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    const-string v3, "t"

    invoke-interface {v2, v3, v0, v1}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;J)Lcom/ta/utdid2/core/persistent/b$a;

    .line 365
    :cond_1
    return-void
.end method

.method private f(Ljava/lang/String;)J
    .locals 3

    .prologue
    const-wide/16 v0, 0x0

    .line 457
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 458
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v2, :cond_1

    .line 459
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v2, p1, v0, v1}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v0

    .line 463
    :cond_0
    :goto_0
    return-wide v0

    .line 460
    :cond_1
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v2, :cond_0

    .line 461
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0, p1}, Lcom/ta/utdid2/core/persistent/b;->b(Ljava/lang/String;)J

    move-result-wide v0

    goto :goto_0
.end method

.method private f()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "*>;"
        }
    .end annotation

    .prologue
    .line 487
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 488
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v0, :cond_0

    .line 489
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v0}, Landroid/content/SharedPreferences;->getAll()Ljava/util/Map;

    move-result-object v0

    .line 493
    :goto_0
    return-object v0

    .line 490
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v0, :cond_1

    .line 491
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0}, Lcom/ta/utdid2/core/persistent/b;->b()Ljava/util/Map;

    move-result-object v0

    goto :goto_0

    .line 493
    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private g(Ljava/lang/String;)F
    .locals 2

    .prologue
    const/4 v0, 0x0

    .line 467
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 468
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v1, :cond_1

    .line 469
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v1, p1, v0}, Landroid/content/SharedPreferences;->getFloat(Ljava/lang/String;F)F

    move-result v0

    .line 473
    :cond_0
    :goto_0
    return v0

    .line 470
    :cond_1
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v1, :cond_0

    .line 471
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0, p1}, Lcom/ta/utdid2/core/persistent/b;->c(Ljava/lang/String;)F

    move-result v0

    goto :goto_0
.end method

.method private h(Ljava/lang/String;)Z
    .locals 2

    .prologue
    const/4 v0, 0x0

    .line 477
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 478
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v1, :cond_1

    .line 479
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-interface {v1, p1, v0}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    .line 483
    :cond_0
    :goto_0
    return v0

    .line 480
    :cond_1
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v1, :cond_0

    .line 481
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v0, p1}, Lcom/ta/utdid2/core/persistent/b;->d(Ljava/lang/String;)Z

    move-result v0

    goto :goto_0
.end method


# virtual methods
.method public final a(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 313
    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    const-string v0, "t"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 314
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 315
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v0, :cond_0

    .line 316
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0, p1}, Landroid/content/SharedPreferences$Editor;->remove(Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 318
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v0, :cond_1

    .line 319
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v0, p1}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b$a;

    .line 322
    :cond_1
    return-void
.end method

.method public final a(Ljava/lang/String;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 301
    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    const-string v0, "t"

    invoke-virtual {p1, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 302
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->c()V

    .line 303
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v0, :cond_0

    .line 304
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v0, p1, p2}, Landroid/content/SharedPreferences$Editor;->putString(Ljava/lang/String;Ljava/lang/String;)Landroid/content/SharedPreferences$Editor;

    .line 306
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v0, :cond_1

    .line 307
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v0, p1, p2}, Lcom/ta/utdid2/core/persistent/b$a;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b$a;

    .line 310
    :cond_1
    return-void
.end method

.method public final a()Z
    .locals 6

    .prologue
    const/4 v1, 0x0

    .line 368
    const/4 v0, 0x1

    .line 369
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 370
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    if-eqz v4, :cond_1

    .line 371
    iget-boolean v4, p0, Lcom/ta/utdid2/core/persistent/c;->n:Z

    if-nez v4, :cond_0

    .line 372
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v4, :cond_0

    .line 373
    iget-object v4, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    const-string v5, "t"

    invoke-interface {v4, v5, v2, v3}, Landroid/content/SharedPreferences$Editor;->putLong(Ljava/lang/String;J)Landroid/content/SharedPreferences$Editor;

    .line 376
    :cond_0
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->j:Landroid/content/SharedPreferences$Editor;

    invoke-interface {v2}, Landroid/content/SharedPreferences$Editor;->commit()Z

    move-result v2

    if-nez v2, :cond_1

    move v0, v1

    .line 380
    :cond_1
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v2, :cond_2

    .line 381
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->l:Landroid/content/Context;

    if-eqz v2, :cond_2

    .line 382
    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->l:Landroid/content/Context;

    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    invoke-virtual {v2, v3, v1}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;

    move-result-object v2

    iput-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    .line 386
    :cond_2
    const/4 v2, 0x0

    .line 388
    :try_start_0
    invoke-static {}, Landroid/os/Environment;->getExternalStorageState()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v2

    .line 392
    :goto_0
    invoke-static {v2}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v3

    if-nez v3, :cond_5

    .line 393
    const-string v3, "mounted"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    .line 394
    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-nez v3, :cond_7

    .line 396
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->d:Ljava/lang/String;

    invoke-direct {p0, v1}, Lcom/ta/utdid2/core/persistent/c;->c(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/d;

    move-result-object v1

    .line 397
    if-eqz v1, :cond_3

    .line 398
    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    invoke-virtual {v1, v3}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v1

    iput-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    .line 400
    iget-boolean v1, p0, Lcom/ta/utdid2/core/persistent/c;->n:Z

    if-nez v1, :cond_6

    .line 401
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-static {v1, v3}, Lcom/ta/utdid2/core/persistent/c;->a(Landroid/content/SharedPreferences;Lcom/ta/utdid2/core/persistent/b;)V

    .line 405
    :goto_1
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    invoke-interface {v1}, Lcom/ta/utdid2/core/persistent/b;->c()Lcom/ta/utdid2/core/persistent/b$a;

    move-result-object v1

    iput-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    .line 415
    :cond_3
    :goto_2
    const-string v1, "mounted"

    invoke-virtual {v2, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    .line 417
    const-string v1, "mounted_ro"

    invoke-virtual {v2, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_5

    .line 418
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v1, :cond_5

    .line 420
    :cond_4
    :try_start_1
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    if-eqz v1, :cond_5

    .line 421
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->m:Lcom/ta/utdid2/core/persistent/d;

    iget-object v2, p0, Lcom/ta/utdid2/core/persistent/c;->c:Ljava/lang/String;

    invoke-virtual {v1, v2}, Lcom/ta/utdid2/core/persistent/d;->a(Ljava/lang/String;)Lcom/ta/utdid2/core/persistent/b;

    move-result-object v1

    iput-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1

    .line 429
    :cond_5
    :goto_3
    return v0

    .line 390
    :catch_0
    move-exception v3

    invoke-virtual {v3}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    .line 403
    :cond_6
    iget-object v1, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    invoke-static {v1, v3}, Lcom/ta/utdid2/core/persistent/c;->a(Lcom/ta/utdid2/core/persistent/b;Landroid/content/SharedPreferences;)V

    goto :goto_1

    .line 408
    :cond_7
    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    if-eqz v3, :cond_3

    .line 409
    iget-object v3, p0, Lcom/ta/utdid2/core/persistent/c;->k:Lcom/ta/utdid2/core/persistent/b$a;

    invoke-interface {v3}, Lcom/ta/utdid2/core/persistent/b$a;->b()Z

    move-result v3

    if-nez v3, :cond_3

    move v0, v1

    .line 410
    goto :goto_2

    :catch_1
    move-exception v1

    goto :goto_3
.end method

.method public final b(Ljava/lang/String;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 433
    invoke-direct {p0}, Lcom/ta/utdid2/core/persistent/c;->b()Z

    .line 434
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    if-eqz v0, :cond_0

    .line 435
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->h:Landroid/content/SharedPreferences;

    const-string v1, ""

    invoke-interface {v0, p1, v1}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 436
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 443
    :goto_0
    return-object v0

    .line 440
    :cond_0
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    if-eqz v0, :cond_1

    .line 441
    iget-object v0, p0, Lcom/ta/utdid2/core/persistent/c;->i:Lcom/ta/utdid2/core/persistent/b;

    const-string v1, ""

    invoke-interface {v0, p1, v1}, Lcom/ta/utdid2/core/persistent/b;->a(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 443
    :cond_1
    const-string v0, ""

    goto :goto_0
.end method
